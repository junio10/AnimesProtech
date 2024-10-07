using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Exceptions;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public class AnimeRepository : IAnimeRepository

{
    private readonly ProtechAnimesContext _context;

    public AnimeRepository(ProtechAnimesContext context)
    {
        _context = context;
    }
    public async Task<Anime?> Add(Anime anime)
    {
        var director = await _context.Directors.FirstOrDefaultAsync(d => d.Id == anime.DirectorId);
        if (director is null)
        {
           throw new NotFoundException("diretor não encontrado");

        }
       anime.Director = director;
       await _context.AddAsync(anime);
       await _context.SaveChangesAsync();
       return anime;
        
    }

    public async Task<IEnumerable<Anime?>> AnimesByIdDirector(int id)
    {
        return await _context.Animes
         .Where(a => a.DirectorId == id)
         .ToListAsync();
    }

    public async Task<Anime?> Delete(int id)
    {
        var anime = await _context.Animes.FindAsync(id);
        if(anime is null) {
            throw new NotFoundException("Não existe o anime informado");
        }
        _context.Animes.Remove(anime);

        await _context.SaveChangesAsync();

        return anime; 
    }

    public async Task<Anime?> GetAnimeByName(string name)
    {
        return await _context.Animes.
            Where(a => a.Name == name).
            FirstOrDefaultAsync();

    }

    public async Task<IEnumerable<Anime?>> GetAnimesByKeyWords(string summary)
    {
        return await _context.Animes.
            Where(a => EF.Functions.Like(a.Summary, $"%{summary}%"))
            .ToListAsync();
    }

    public async Task<Anime?> Update(Anime animeUpdate)
    {
        var anime = await _context.Animes.
            Where(a => a.Id == animeUpdate.Id).FirstOrDefaultAsync();
        if (anime is null)
        {
            throw new NotFoundException("anime não encontrado");
        }
        anime.Name = animeUpdate.Name;
        anime.Summary = animeUpdate.Summary;
        anime.Director = animeUpdate.Director;

        await _context.SaveChangesAsync();
        return anime;
    }

    public async Task<Anime?> GetAnimeById(int id)
    {
        return await _context.Animes.Where(a => a.Id == id).
            FirstOrDefaultAsync();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Anime>> GetAllAnimes()
    {
        return await _context.Animes.ToListAsync();
    }
}
