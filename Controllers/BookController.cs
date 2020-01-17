using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using book_store.Models;
using book_store.Models.repositories;
using book_store.view_models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace book_store.Controllers
{
    public class BookController : Controller
    {
        private readonly repositoriesInterface<Book> bookrepository;
        private readonly repositoriesInterface<Auther> autherrepository;
        private readonly IHostEnvironment hosting;

        public BookController(repositoriesInterface<Book> bookrepository 
            , repositoriesInterface<Auther> autherrepository
            ,IHostEnvironment hosting)
        {
            this.bookrepository = bookrepository;
            this.autherrepository = autherrepository;
            this.hosting = hosting;
        }
        // GET: Book
        public ActionResult Index()
        {
            var books = bookrepository.list();
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = bookrepository.find(id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var model = new book_authermodel
            {
                authers = fillselectedlist()
            };
            return View(model);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(book_authermodel model)
        {
            if (ModelState.IsValid)

            {
                try
                {
                    /* to upload image*/
  /* calluse exceprition*/  string filename = uploadfile(model.File) ?? string.Empty;
                   
                    /* to upload image*/

                    /* to make select items of authers */
                    if (model.Id_auther == -1)
                    {
                        ViewBag.message = "please select an auther from list";
                        return View(getallauthers());
                    }
                    var auther = autherrepository.find(model.Id_auther);

                    Book book = new Book
                    {
                        Idbook = model.Idbook,
                        Title = model.Title,
                        Description = model.Description,
                        Auther = auther,
                        imageurl=filename
                    };
                    bookrepository.add(book);
                    // TODO: Add insert logic here

                    return RedirectToAction(nameof(Index));

                }
                catch
                {
                    return View();
                }
            }

            //var vmmodel = new book_authermodel
            //{
            //    authers = fillselectedlist()
            //};

            ModelState.AddModelError("", "you have to fill required fields");
            return View(getallauthers());


            //ModelState.AddModelError("","you have to fill required fields");
            //return View(getallauthers());
        }

        // GET: Book/Edit/5





        public ActionResult Edit(int id)
        {
            var book = bookrepository.find(id);
            var autherid = book.Auther == null ? book.Auther.Id_auther = 0 : book.Auther.Id_auther;
            var viewmodel = new book_authermodel
            {
                Idbook = book.Idbook
                ,
                Title = book.Title
                ,
                Description = book.Description,
                Id_auther = autherid
                , /*book.Auther.Id_auther,*/
                authers = autherrepository.list().ToList()
                ,
                imageurl = book.imageurl

            };
            return View(viewmodel);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*int id,*/ book_authermodel vmodel)
        {
           
            try
            {
                string filename = string.Empty;
                if (vmodel.File != null)
                {
                    string uploads = Path.Combine(hosting.ContentRootPath, "wwwroot\\uploads");
                    filename = vmodel.File.FileName;
                    string fullpath = Path.Combine(uploads, filename);
                    //delete od fie
                    //string old_image = bookrepository.find(vmodel.Idbook).imageurl; السطر ده بيعمل اكسبشن مع السطر 181
                    string old_image = vmodel.imageurl;
                    string full_old_img = Path.Combine(uploads, old_image);
                   
                    if (fullpath != full_old_img) 
                    {
                        System.IO.File.Delete(full_old_img);

                        //save new file
                        vmodel.File.CopyTo(new FileStream(fullpath, FileMode.Create));
                    }

                   
                }



                var auther = autherrepository.find(vmodel.Id_auther);

                Book book = new Book
                {
                    // Idbook = model.Idbook, dont change
                    Idbook = vmodel.Idbook,
                    Title = vmodel.Title,
                    Description = vmodel.Description,
                   Auther=auther,
                   imageurl=filename
                };
                bookrepository.update(vmodel.Idbook,book);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookrepository.find(id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  confirmDelete(int id) //change name to confirmdelete to overload delete function
        {
            try
            {
                // TODO: Add delete logic here
              
                bookrepository.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        List<Auther> fillselectedlist() 
        {
            var authers = autherrepository.list().ToList();
            authers.Insert( 0, new Auther { Id_auther = -1, Name = " ....please select an auther...." });
            return authers;
        }
        book_authermodel getallauthers()
        {
            var vmodel = new book_authermodel
            {
                authers = fillselectedlist()
            };
            return vmodel;
        }

        string uploadfile(IFormFile file) 
        {
            if (file != null)
            {
                string uploads = Path.Combine(hosting.ContentRootPath, "wwwroot\\uploads");
                string fullpath = Path.Combine(uploads, file.FileName);
                file.CopyTo(new FileStream(fullpath, FileMode.Create));


                return file.FileName;
            }

            return null;
             
        }



        string uploadfile(IFormFile file,string imgurl)
        {
            if (file != null)
            {
                string uploads = Path.Combine(hosting.ContentRootPath, "wwwroot\\uploads");
                string fullpath = Path.Combine(uploads, file.FileName);
                file.CopyTo(new FileStream(fullpath, FileMode.Create));


                return file.FileName;
            }

            return null;

        }


        public ActionResult search(string term) 
        {
            var result = bookrepository.search(term);
            return View("Index",result);
        }
    }

}