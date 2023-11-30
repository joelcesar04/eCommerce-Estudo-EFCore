﻿using eCommerce.API.Database;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

var db = new eCommerceContext();

// Add, Update, Remove

var usuario01 = new Usuario { Nome = "Elias" };
db.Usuarios.Add(usuario01);

var usuario02 = db.Usuarios.Find(2);
usuario02!.Nome = "Josefina";
db.Usuarios.Update(usuario02);

var usuario03 = db.Usuarios.Find(3);
db.Usuarios.Remove(usuario03!);

var usuario04 = new Usuario() { Id = 4, Nome = "Filipe Almeida Brandão", NomeMae = "Josefina" };
db.Usuarios.Attach(usuario04);

db.Entry(usuario04).Property(x => x.NomeMae).IsModified = false;
db.Entry(usuario04).Property(x => x.Nome).IsModified = true;

Console.WriteLine(db.ChangeTracker.DebugView.LongView);

#region TrackingNoTracking
//var usuario01 = db.Usuarios.FirstOrDefault(a => a.Id == 1);
//usuario01!.Nome = "José Ribeiro";

//db.SaveChanges();

//var usuario01 = db.Usuarios.AsNoTracking().FirstOrDefault(a => a.Id == 1);
//usuario01!.Nome = "José Ribeiro";

//db.Update(usuario01);
//db.SaveChanges();
#endregion