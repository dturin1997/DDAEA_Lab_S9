using DDAEA_Lab_S9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDAEA_Lab_S9.Controllers
{
    public class productController : Controller
    {
        private NeptunoEntities db = new NeptunoEntities();
        // GET: product
        public ActionResult Index()
        {
            return View(db.productos.ToList());
        }

        // GET: product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: product/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombreProducto,idProveedor,idCategoria")] productos productos)
        {
            if (ModelState.IsValid)
            {
                int id;
                id = db.productos.Max(x => x.idproducto);
                productos.idproducto = id +1;
                db.productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productos);
        }

    }
}