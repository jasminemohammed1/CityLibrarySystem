using CityLibrarySystem.Context;
using CityLibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Helper
{
    internal static class LoanManagement
    {
        public static bool BorrowingBook(int MemberId , int BookId , int BorrowDays , LibraryDbContext dbcontext)
        {
            var tran = dbcontext.Database.BeginTransaction();
            try
            {
             var member = dbcontext.Members.FirstOrDefault(x=>x.Id == MemberId);
                if(member == null || member.Status==Enums.MemberStatus.Suspended)
                {
                    return false;
                }

                var book = dbcontext.Books.FirstOrDefault(x=>x.Id == BookId);
                if (book == null || book.AvailableCopies == 0) { 
                    return false;
                }
                var laoan = new Loan();
                dbcontext.Loans.Add(laoan);
                MemberLoan memberLoan = new MemberLoan()
                {
                  MemberId = MemberId,
                  BookId = BookId,
                  Loan = laoan,
                  DueDate = DateTime.Now.AddDays(BorrowDays)

                };
                dbcontext.MemberLoans.Add(memberLoan);
                book.AvailableCopies--;
                dbcontext.SaveChanges();
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                throw;
               
            }

        }
        public static bool ReturnBook(int MemberId ,int BookId , LibraryDbContext dbContext)
        {
            var memberloan = dbContext.MemberLoans.Include(x => x.Loan)
                .Include(x => x.Book)
                .FirstOrDefault(x => x.MemberId == MemberId && x.BookId == BookId && x.ReturnDate==null);
            if(memberloan == null) { return false; }
            memberloan.ReturnDate = DateTime.Now;
            memberloan.Book.AvailableCopies++;
            if(memberloan.ReturnDate.Value.Date > memberloan.DueDate.Date)
            {
                var OverDueDays = (memberloan.ReturnDate.Value - memberloan.DueDate.Date).Days;
                var dailyFine = 0.1M * memberloan.Book.Price;
                var fine = new Fine()
                {
                    Amount = OverDueDays * dailyFine,
                    Loan = memberloan.Loan
                };
                dbContext.Fines.Add(fine);
                memberloan.Loan.LoanStatus = Enums.LoanStatus.Overdue;
                var mem = dbContext.Members.FirstOrDefault(x => x.Id == MemberId);
                mem.Status = Enums.MemberStatus.Suspended;
            }
            else
            {
                memberloan.Loan.LoanStatus = Enums.LoanStatus.Returned;
            }
            dbContext.SaveChanges();
            return true;
        }
    }
}
