﻿/*Kampımızla beraber paralelde geliştireceğimiz bir projemiz daha olacak. Araba kiralama sistemi yazıyoruz.

Yepyeni bir proje oluşturunuz. Adı ReCapProject olacak. (Tekrar ve geliştirme projesi)

Entities, DataAccess, Business ve Console katmanlarını oluşturunuz.

Bir araba nesnesi oluşturunuz. "Car"

Özellik olarak : Id, BrandId, ColorId, ModelYear, DailyPrice, Description alanlarını ekleyiniz. (Brand = Marka)

InMemory formatta GetById, GetAll, Add, Update, Delete oprasyonlarını yazınız.

Consolda test ediniz.

Önemli: Copy - Paste yasak fakat kamp projesinden destek almak serbest.

Kodlarınızı Github'a aktarıp paylaşınız. İncelediğiniz arkadaşlarınıza yıldız vermeyi unutmayınız.*/

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System.Net.Http.Headers;

/*CarManager carManager = new CarManager(new InMemoryCarDal());

foreach (var car in carManager.GetCars())
{
    Console.WriteLine(car.BrandId + " " + car.Description);
}
*/


GetCarDetailsTest();






















static void GetCarDetailsTest()
{
    CarManager carManager = new CarManager(new EfCardal());

    var result = carManager.GetCarDetails();

    if (result.Success)
    {
        foreach (var car in carManager.GetCarDetails().Data)
        {
            Console.WriteLine(car.BrandName + car.ModelName + " / " + car.ColorName + " / " + car.DailyPrice);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}

