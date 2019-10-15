﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Entity = MusicStore.Contracts.IArtist;
using Model = MusicStore.Transfer.Models.Artist;
using Factory = MusicStore.Logic.Factory;

namespace MusicStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        // GET: api/Artist
        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            using (var ctrl = Factory.CreateController<Entity>())
            {
                return ctrl.GetAll();
            }
        }

        // GET: api/Artist/5
        [HttpGet("{id}")]
        public Entity Get(int id)
        {
            using (var ctrl = Factory.CreateController<Entity>())
            {
                return ctrl.GetById(id);
            }
        }

        // POST: api/Artist
        [HttpPost]
        public void Post([FromBody] Model model)
        {
            using (var ctrl = Factory.CreateController<Entity>())
            {
                ctrl.Insert(model);
                ctrl.Save();
            }
        }

        // PUT: api/Artist/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Model model)
        {
            using (var ctrl = Factory.CreateController<Entity>())
            {
                ctrl.Update(model);
                ctrl.Save();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var ctrl = Factory.CreateController<Entity>())
            {
                ctrl.Delete(id);
                ctrl.Save();
            }
        }
    }
}