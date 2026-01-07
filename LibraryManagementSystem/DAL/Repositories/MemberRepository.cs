using LibraryManagementSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryManagementSystem.DAL.Repositories
{
    public class MemberRepository : IRepository<Member>
    {
        private const int ID_Length = 5;
        private const int FULLNAME_Length = 30;
        private const int EMAIL_Length = 30;
        private const int PHONE_Length = 15;
        private const int DATE_Length = 10; 
        private const int ACTIVE_Length = 1;

        private readonly string filePath = "Data/members.txt";

     
        public void Add(Member member)
        {
            string line =
                member.Id.ToString().PadLeft(ID_Length, '0') +
                member.FullName.PadRight(FULLNAME_Length) +
                member.Email.PadRight(EMAIL_Length) +
                member.PhoneNumber.PadRight(PHONE_Length) +
                member.MembershipDate.ToString("yyyy-MM-dd") +
                (member.IsActive ? "1" : "0");

            File.AppendAllText(filePath, line + Environment.NewLine);
        }

       
        public List<Member> GetAll()
        {
            List<Member> members = new List<Member>();

            if (!File.Exists(filePath))
                return members;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                Member member = new Member
                {
                    Id = int.Parse(line.Substring(0, ID_Length)),
                    FullName = line.Substring(ID_Length, FULLNAME_Length).Trim(),
                    Email = line.Substring(ID_Length + FULLNAME_Length, EMAIL_Length).Trim(),
                    PhoneNumber = line.Substring(ID_Length + FULLNAME_Length + EMAIL_Length, PHONE_Length).Trim(),
                    MembershipDate = DateTime.Parse(line.Substring(ID_Length + FULLNAME_Length + EMAIL_Length + PHONE_Length, DATE_Length)),
                    IsActive = line.Substring(ID_Length + FULLNAME_Length + EMAIL_Length + PHONE_Length + DATE_Length, ACTIVE_Length) == "1"
                };
                members.Add(member);
            }

            return members;
        }

        
        public Member GetById(int id)
        {
            List<Member> members = GetAll();
            foreach (var m in members)
                if (m.Id == id) return m;
            return null;
        }

      
        public void Update(Member entity)
        {
            List<Member> members = GetAll();
            bool updated = false;

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Id == entity.Id)
                {
                    members[i] = entity;
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    foreach (var m in members)
                    {
                        string line =
                            m.Id.ToString().PadLeft(ID_Length, '0') +
                            m.FullName.PadRight(FULLNAME_Length) +
                            m.Email.PadRight(EMAIL_Length) +
                            m.PhoneNumber.PadRight(PHONE_Length) +
                            m.MembershipDate.ToString("yyyy-MM-dd") +
                            (m.IsActive ? "1" : "0");

                        sw.WriteLine(line);
                    }
                }
            }
        }

     
        public void Delete(int id)
        {
            List<Member> members = GetAll();
            members.RemoveAll(m => m.Id == id);

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (var m in members)
                {
                    string line =
                        m.Id.ToString().PadLeft(ID_Length, '0') +
                        m.FullName.PadRight(FULLNAME_Length) +
                        m.Email.PadRight(EMAIL_Length) +
                        m.PhoneNumber.PadRight(PHONE_Length) +
                        m.MembershipDate.ToString("yyyy-MM-dd") +
                        (m.IsActive ? "1" : "0");

                    sw.WriteLine(line);
                }
            }
        }

       
        public List<Member> Search(string keyword)
        {
            List<Member> members = GetAll();
            List<Member> result = new List<Member>();

            foreach (var m in members)
            {
                if ((m.FullName != null && m.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (m.Email != null && m.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                {
                    result.Add(m);
                }
            }

            return result;
        }
    }
}
