﻿using ControlPanel_API.DBContext;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ControlPanel_API.Repositories.Services
{
    public class RolesService : IRolesService
    {
        private readonly AppDbContext _context;
        public RolesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Role> AddRole(Role request)
        {
            try
            {
                var role = new Role
                {
                    RoleName = request.RoleName,
                    RoleCode = request.RoleCode,
                    RoleNumber = request.RoleNumber,
                    Status = request.Status,

                };

                _context.tblRole.Add(role);
                _context.SaveChanges();

                return await Task.FromResult(role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Role> UpdateRole(Role role)
        {
            try
            {
                var data = _context.tblRole.Where(x => x.RoleId == role.RoleId).FirstOrDefault();
                if (data != null)
                {
                    data.RoleName = role.RoleName;
                    data.RoleCode = role.RoleCode;
                    data.RoleNumber = role.RoleNumber;
                    data.Status = role.Status;

                    _context.tblRole.Update(role);
                    _context.SaveChanges();
                    _context.Entry(data).State = EntityState.Detached;
                    return await Task.FromResult(role);

                }
                else
                {
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Role>> GetRoles()
        {
            try
            {
                return _context.tblRole.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<Role> GetRoleByID(int roleId)
        {
            try
            {
                var data = _context.tblRole.Where(x => x.RoleId == roleId).FirstOrDefault();
                if (data != null)
                {
                    return Task.FromResult(data);
                }
                else
                {
                    return Task.FromResult<Role>(null);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
