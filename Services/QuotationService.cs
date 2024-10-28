﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAB251_A2.Models;
namespace IAB251_A2.Services
{
    public class QuotationService
    {
        private static QuotationService _instance;
        public static QuotationService Instance => _instance ??= new QuotationService();

        private List<Quotation> quotations = new List<Quotation>();

        private QuotationService() { }

        public string SubmitQuotation(Quotation quotation)
        {
            quotation.RequestID = quotations.Count + 1;
            quotation.Status = "Pending";
            quotation.DateIssued = DateTime.Now;
            quotations.Add(quotation);
            return "Quotation submitted successfully!";
        }

        public List<Quotation> GetPendingQuotations()
        {
            return quotations.Where(q => q.Status == "Pending").ToList();
        }

        public void UpdateQuotationStatus(int requestId, string status)
        {
            var quotation = quotations.FirstOrDefault(q => q.RequestID == requestId);
            if (quotation != null)
            {
                quotation.Status = status;
            }
        }
    }
}