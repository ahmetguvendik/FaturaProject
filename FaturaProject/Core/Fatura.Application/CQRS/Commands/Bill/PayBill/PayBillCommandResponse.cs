﻿using System;
namespace Fatura.Application.CQRS.Commands.Bill.PayBill
{
	public class PayBillCommandResponse
	{
        public string CardNumaber { get; set; }
        public string CardDateTıme { get; set; }
        public string CVC { get; set; }
        public bool IsPay { get; set; }
    }
}

