using LibraryManagementSystem.BLL;
using LibraryManagementSystem.DAL.Entities;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.UI
{
    public static class MemberUI
    {
        private static MemberService memberService = new MemberService();

        public static void AddMemberUI()
        {
            try
            {
                Console.Write("Uzv ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Tam ad: ");
                string name = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Telefon nomresi: ");
                string phone = Console.ReadLine();

                Console.Write("Uzvluk tarixi (yyyy-mm-dd): ");
                DateTime membershipDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Aktivdir? (1 = Beli, 0 = Xeyr): ");
                bool isActive = Console.ReadLine() == "1";

                var member = new Member
                {
                    Id = id,
                    FullName = name,
                    Email = email,
                    PhoneNumber = phone,
                    MembershipDate = membershipDate,
                    IsActive = isActive
                };

                memberService.AddMember(member);

                Console.WriteLine("Uzv ugurla elave olundu! Enter basin...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
                Console.WriteLine("Enter basin...");
                Console.ReadLine();
            }
        }

        public static void ListMembersUI()
        {
            Console.Clear();
            var members = memberService.GetAllMembers();
            foreach (var m in members)
            {
                Console.WriteLine($"ID: {m.Id} | Name: {m.FullName} | Email: {m.Email} | Phone: {m.PhoneNumber} | Date: {m.MembershipDate.ToShortDateString()} | Active: {(m.IsActive ? "Beli" : "Xeyr")}");
            }
            Console.WriteLine("Enter basin...");
            Console.ReadLine();
        }

        public static void GetMemberByIdUI()
        {
            Console.Write("Uzv ID daxil edin: ");
            int id = int.Parse(Console.ReadLine());

            var member = memberService.GetMemberById(id);
            if (member != null)
            {
                Console.WriteLine($"ID: {member.Id} | Name: {member.FullName} | Email: {member.Email} | Phone: {member.PhoneNumber} | Date: {member.MembershipDate.ToShortDateString()} | Active: {(member.IsActive ? "Beli" : "Xeyr")}");
            }
            else
            {
                Console.WriteLine("Uzv tapilmadi!");
            }
            Console.WriteLine("Enter basin...");
            Console.ReadLine();
        }

        public static void UpdateMemberUI()
        {
            Console.Write("Yenilemek istediyiniz uzv ID: ");
            int id = int.Parse(Console.ReadLine());

            var member = memberService.GetMemberById(id);
            if (member == null)
            {
                Console.WriteLine("Uzv tapilmadi! Enter basin...");
                Console.ReadLine();
                return;
            }

            Console.Write($"Yeni Name ({member.FullName}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) member.FullName = name;

            Console.Write($"Yeni Email ({member.Email}): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) member.Email = email;

            Console.Write($"Yeni Phone ({member.PhoneNumber}): ");
            string phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone)) member.PhoneNumber = phone;

            Console.Write($"Yeni MembershipDate ({member.MembershipDate.ToShortDateString()}): ");
            string dateInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dateInput)) member.MembershipDate = DateTime.Parse(dateInput);

            Console.Write($"Aktivdir? ({(member.IsActive ? "Beli" : "Xeyr")}) (1/0): ");
            string activeInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(activeInput)) member.IsActive = activeInput == "1";

            memberService.UpdateMember(member);

            Console.WriteLine("Uzv yenilendi! Enter basin...");
            Console.ReadLine();
        }

        public static void DeleteMemberUI()
        {
            Console.Write("Silmek istediyiniz uzv ID: ");
            int id = int.Parse(Console.ReadLine());

            memberService.DeleteMember(id);

            Console.WriteLine("Uzv silindi! Enter basin...");
            Console.ReadLine();
        }

        public static void SearchMemberUI()
        {
            Console.Write("Axtarish sozunu daxil edin (ad/email üzrə): ");
            string keyword = Console.ReadLine();

            var members = memberService.SearchMembers(keyword);
            foreach (var m in members)
            {
                Console.WriteLine($"ID: {m.Id} | Name: {m.FullName} | Email: {m.Email} | Phone: {m.PhoneNumber} | Date: {m.MembershipDate.ToShortDateString()} | Active: {(m.IsActive ? "Beli" : "Xeyr")}");
            }
            Console.WriteLine("Enter basin...");
            Console.ReadLine();
        }
    }
}
