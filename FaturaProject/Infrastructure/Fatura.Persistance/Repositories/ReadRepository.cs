﻿using System;
using Fatura.Application.Repositories;
using Fatura.Application.ViewModel;
using Fatura.Domain.Entities;
using Fatura.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Fatura.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : Bill
    {
        private readonly BillDbContext _context;
        public ReadRepository(BillDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable GetAll()
        {
            return Table;
        }

        public async Task<T> GetByBillId(string id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public List<BillUserViewModel> GetById(string id)
        {
            var query = (from bill in _context.Set<Bill>()
                         join user in _context.Set<AppUser>()
                            on bill.UserId equals user.Id
                         where user.Id == id
                         select new BillUserViewModel() {Id=bill.Id, Name = bill.Name, Price = bill.Price, UserName = user.UserName,IsPay = bill.IsPay }).ToList();
            return query;
        }

        public IQueryable<UserRoleViewModel> GetUserRole()
        {
            var model = from user in _context.Users
                        join userRole in _context.UserRoles
                        on user.Id equals userRole.UserId
                        join role in _context.Roles
                        on userRole.RoleId equals role.Id
                        select new UserRoleViewModel
                        {
                            UserId = user.UserName,
                            RoleId = role.Name
                        };

            return model;
        }

        

       
    }
}

