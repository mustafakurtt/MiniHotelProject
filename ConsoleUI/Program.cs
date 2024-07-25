// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.Contexts;

Console.WriteLine("Hello, World!");

var roomDal = new RoomDal(new BaseContext());
var roomManager = new RoomManager(roomDal);
