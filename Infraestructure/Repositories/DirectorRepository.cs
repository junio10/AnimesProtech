using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Exceptions;
using Infraestructure.Context;
using Infraestructure.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public class DirectorRepository : IDirectorRepository
{
    private readonly ProtechAnimesContext _context;
    
    public DirectorRepository(ProtechAnimesContext context)
    {
        _context = context;
    }
    public async Task<Director> Add(Director director)
    {
        await _context.Directors.AddAsync(director);
        await _context.SaveChangesAsync();
        return director;
    }

    public async Task<IEnumerable<Director>> GetAllDirectors()
    {
        return await _context.Directors.ToListAsync();
    }

    public async Task<Director> GetDirectorById(int id)
    {
        return await _context.Directors.Where(d => d.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Director> GetDirectorByName(string name)
    {
        return await _context.Directors.Where(d => d.Name == name)
            .FirstOrDefaultAsync();
    }

    public async Task<Director> Update(Director directorUpdate)
    {
       var director = await _context.Directors.Where(d => d.Id == directorUpdate.Id)
            .FirstOrDefaultAsync();
        if (director != null)
        {
            throw new NotFoundException("diretor não encontrado");
        }
        director.Name = directorUpdate.Name;
        await _context.SaveChangesAsync();
        return director;

    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
