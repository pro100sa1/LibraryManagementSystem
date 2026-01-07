using LibraryManagementSystem.DAL.Entities;
using LibraryManagementSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem.BLL
{
    public class MemberService
    {
        private readonly MemberRepository _repo;

        public MemberService()
        {
            _repo = new MemberRepository();
        }

    
        public void AddMember(Member member)
        {
            if (string.IsNullOrWhiteSpace(member.FullName))
                throw new Exception("FullName bosh ola bilmez!");
            if (string.IsNullOrWhiteSpace(member.Email) || !Regex.IsMatch(member.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("Email duzgun olmalidir!");

            _repo.Add(member);
        }

        
        public List<Member> GetAllMembers()
        {
            return _repo.GetAll();
        }

        
        public Member GetMemberById(int id)
        {
            return _repo.GetById(id);
        }

      
        public void UpdateMember(Member member)
        {
            if (string.IsNullOrWhiteSpace(member.FullName))
                throw new Exception("FullName bosh ola bilmez!");
            if (string.IsNullOrWhiteSpace(member.Email) || !Regex.IsMatch(member.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("Email duzgün olmalidir!");

            _repo.Update(member);
        }

        public void DeleteMember(int id)
        {
            _repo.Delete(id);
        }

      
        public List<Member> SearchMembers(string keyword)
        {
            return _repo.Search(keyword);
        }
    }
}
