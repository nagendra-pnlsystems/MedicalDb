using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicalDb.Models;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO.Compression;
using PagedList;
using MedicalDb.Helpers;
//using MedicalDb.Helpers;


namespace MedicalDb.Controllers
{
    public class EntryModelsController : Controller
    {
        private medicaldbEntities db = new medicaldbEntities();

        // GET: EntryModels
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string companycurrentFilter, string companysearchString, string employeecurrentFilter, string employeesearchString, int? page)
        {
            var entryModel = db.entrymodels.Include(e => e.grosssalary).Include(e => e.relationship);
            if (companysearchString != null)
            {
                page = 1;
            }
            else
            {
                companysearchString = companycurrentFilter;
            }
            if (employeesearchString != null)
            {
                page = 1;
            }
            else
            {
                employeesearchString = employeecurrentFilter;
            }
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = companysearchString;
            ViewBag.CurrentFilter1 = employeesearchString;
            ViewBag.CurrentFilter2 = searchString;
            var data = from s in db.entrymodels.ToList()
                       select s;
            if (!String.IsNullOrEmpty(companysearchString))
            {
                data = data.Where(s => s.Company_Name.ToUpper().Contains(companysearchString.ToUpper()));
            }
            if (!String.IsNullOrEmpty(employeesearchString))
            {
                data = data.Where(s => s.Beneficiary_First_Name.ToUpper().Contains(employeesearchString.ToUpper()));
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(s => s.Principal_First_Name.ToUpper().Contains(searchString.ToUpper()) || s.policy.ToUpper().Contains(searchString.ToUpper()) || s.insurance_companyname.ToUpper().Contains(searchString.ToUpper()) || s.PhoneNumber.Contains(searchString));
            }
            ViewBag.FNameSortParm = String.IsNullOrEmpty(sortOrder) ? "FName_desc" : "";
            ViewBag.PNameSortParm = String.IsNullOrEmpty(sortOrder) ? "PName_desc" : "";
            ViewBag.RelSortParm = String.IsNullOrEmpty(sortOrder) ? "Relation_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date_desc" : "";
            ViewBag.CatSortParm = String.IsNullOrEmpty(sortOrder) ? "Category_desc" : "";
            ViewBag.GenSortParm = String.IsNullOrEmpty(sortOrder) ? "Gender_desc" : "";
            ViewBag.ICSortParm = String.IsNullOrEmpty(sortOrder) ? "IC_desc" : "";
            ViewBag.policySortParm = String.IsNullOrEmpty(sortOrder) ? "policy_desc" : "";
            ViewBag.EmailSortParm = String.IsNullOrEmpty(sortOrder) ? "Email_desc" : "";
            switch (sortOrder)
            {
                case "FName_desc":
                    data = data.OrderBy(s => s.Beneficiary_First_Name);
                    break;
                case "PName_desc":
                    data = data.OrderBy(s => s.Principal_First_Name);
                    break;

                case "Category_desc":
                    data = data.OrderBy(s => s.Category);
                    break;
                case "Gender_desc":
                    data = data.OrderBy(s => s.gender.Name);
                    break;
                case "Relation_desc":
                    data = data.OrderBy(s => s.relationship.RelationName);
                    break;
                case "IC_desc":
                    data = data.OrderBy(s => s.insurance_companyname);
                    break;
                case "policy_desc":
                    data = data.OrderBy(s => s.policy);
                    break;
                case "Email_desc":
                    data = data.OrderBy(s => s.Email);
                    break;

                case "Date_desc":
                    data = data.OrderBy(s => s.DOB);
                    break;


                default:
                    data = data.OrderBy(s => s.EntryId);
                    break;
            }
            //int pageSize = 10;
            //int pageNumber = (page ?? 1);
            //return View(data.ToPagedList(pageNumber, pageSize));
            return View(data.ToList());
        }

        // GET: EntryModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrymodel entryModel = db.entrymodels.Find(id);
            if (entryModel == null)
            {
                return HttpNotFound();
            }
            return View(entryModel);
        }

        // GET: EntryModels/Create
        public ActionResult Create()
        {
            entrymodel model = new entrymodel();
            model.Date_Time = GetIndianDateTime().ToString();
            ViewBag.Sid = new SelectList(db.grosssalaries, "Sid", "Value");
            ViewBag.Rid = new SelectList(db.relationships, "Rid", "RelationName");
            ViewBag.maritalstatus_id = new SelectList(db.marital_status, "maritalstatus_id", "Name");
            ViewBag.gender_id = new SelectList(db.genders, "gender_id", "Name");
            ViewBag.visacategory_id = new SelectList(db.visa_category, "visacategory_id", "Name");
            return View();
        }

        // POST: EntryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntryId,Beneficiary_First_Name,Beneficiary_Middle_Name,Beneficiary_Last_Name,Principal_First_Name,Principal_Middle_Name,Principal_Last_Name,DOB,maritalstatus_id,visacategory_id,Passport_Number,Category,Nationality,gender_id,Emirates_ID,City_of_Residence,Date_Time,Company_Name,insurance_companyname,policy,UID_Number,SubGroup_Name,Emirates_Of_Visa,Work_Location,Entity_Id,Entity_Type,Establishment_Id,photo,Visa,passport_copy,Emirates_id_copy,medical_card,other_documents,Rid,Sid,PhoneNumber,Email,other_field_1,other_field_2,other_field_3")] entrymodel entryModel, HttpPostedFileBase photo, HttpPostedFileBase visa, HttpPostedFileBase medical_card, HttpPostedFileBase emirates_id_copy, HttpPostedFileBase passport_copy, HttpPostedFileBase other_documents)
        {
            if (ModelState.IsValid)
            {
                if (photo!=null && photo.ContentLength > 0 )
                {
                    var fileName = Path.GetFileName(photo.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_photo" + System.IO.Path.GetExtension(photo.FileName));
                    photo.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath =  newpath;
                    entryModel.photo = imagepath;
                  
                }
                else
                {
                    entryModel.photo = String.Empty;
                }
                if(visa!=null && visa.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(visa.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_visa" + System.IO.Path.GetExtension(visa.FileName));
                  
                    visa.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath =  newpath;
                    entryModel.Visa = imagepath;
                   
                }
                else
                {
                    entryModel.Visa = String.Empty;
                }
                if (passport_copy != null && passport_copy.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(passport_copy.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_passport" + System.IO.Path.GetExtension(passport_copy.FileName));

                    passport_copy.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = newpath;
                    entryModel.passport_copy = imagepath;

                }
                else
                {
                    entryModel.passport_copy = String.Empty;
                }
                if (medical_card!=null && medical_card.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(medical_card.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_medicalcard" + System.IO.Path.GetExtension(medical_card.FileName));

                    medical_card.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = newpath;
                    entryModel.medical_card = imagepath;

                }
                else
                {
                    entryModel.medical_card = String.Empty;
                }
                if (emirates_id_copy !=null && emirates_id_copy.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(emirates_id_copy.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_emiratesid" + System.IO.Path.GetExtension(emirates_id_copy.FileName));

                    emirates_id_copy.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = newpath;
                    entryModel.Emirates_id_copy = imagepath;

                }
                else
                {
                    entryModel.Emirates_id_copy = String.Empty;
                }
                if (other_documents!=null && other_documents.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(other_documents.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_other" + System.IO.Path.GetExtension(other_documents.FileName));

                    other_documents.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = newpath;
                    entryModel.other_documents = imagepath;

                }
                else
                {
                    entryModel.other_documents = String.Empty;
                }
                //entryModel.filedetails = fileDetails;
                entryModel.Date_Time = GetIndianDateTime().ToString();
                db.entrymodels.Add(entryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sid = new SelectList(db.grosssalaries, "Sid", "Value", entryModel.Sid);
            ViewBag.Rid = new SelectList(db.relationships, "Rid", "RelationName", entryModel.Rid);
            ViewBag.maritalstatus_id = new SelectList(db.marital_status, "maritalstatus_id", "Name", entryModel.maritalstatus_id);
            ViewBag.gender_id = new SelectList(db.genders, "gender_id", "Name", entryModel.gender_id);
            ViewBag.visacategory_id = new SelectList(db.visa_category, "visacategory_id", "Name", entryModel.visacategory_id);
            return View(entryModel);
        }

        // GET: EntryModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EntryModel entryModel = db.EntryModels.Find(id);
            entrymodel entryModel = db.entrymodels.SingleOrDefault(x => x.EntryId == id);
            if (entryModel == null)
            {
                return HttpNotFound();
            }
            //if(!String.IsNullOrEmpty(entryModel.photo))
            //{
            //    entryModel.photo = String.Format("~/" + AppConstants.DocumentsFolder + "/" + entryModel.photo);
            //}
            //if (!String.IsNullOrEmpty(entryModel.Visa))
            //{
            //    entryModel.Visa = String.Format("~/" + AppConstants.DocumentsFolder + "/" + entryModel.Visa);
            //}
            //if (!String.IsNullOrEmpty(entryModel.medical_card))
            //{
            //    entryModel.medical_card = String.Format("~/" + AppConstants.DocumentsFolder + "/" + entryModel.medical_card);
            //}
            //if (!String.IsNullOrEmpty(entryModel.passport_copy))
            //{
            //    entryModel.passport_copy = String.Format("~/" + AppConstants.DocumentsFolder + "/" + entryModel.passport_copy);
            //}
            //if (!String.IsNullOrEmpty(entryModel.Emirates_id_copy))
            //{
            //    entryModel.Emirates_id_copy = String.Format("~/" + AppConstants.DocumentsFolder + "/" + entryModel.Emirates_id_copy);
            //}
            //if (!String.IsNullOrEmpty(entryModel.other_documents))
            //{
            //    entryModel.other_documents = String.Format("~/" + AppConstants.DocumentsFolder + "/" + entryModel.other_documents);
            //}
            entryModel.Date_Time = GetIndianDateTime().ToString();
            ViewBag.Sid = new SelectList(db.grosssalaries, "Sid", "Value", entryModel.Sid);
            ViewBag.Rid = new SelectList(db.relationships, "Rid", "RelationName", entryModel.Rid);
            ViewBag.maritalstatus_id = new SelectList(db.marital_status, "maritalstatus_id", "Name", entryModel.maritalstatus_id);
            ViewBag.gender_id = new SelectList(db.genders, "gender_id", "Name", entryModel.gender_id);
            ViewBag.visacategory_id = new SelectList(db.visa_category, "visacategory_id", "Name", entryModel.visacategory_id);
            
            return View(entryModel);
        }
        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/Upload_Documents/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }
        // POST: EntryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntryId,Beneficiary_First_Name,Beneficiary_Middle_Name,Beneficiary_Last_Name,Principal_First_Name,Principal_Middle_Name,Principal_Last_Name,DOB,maritalstatus_id,visacategory_id,Passport_Number,Category,Nationality,gender_id,Emirates_ID,City_of_Residence,Date_Time,Company_Name,insurance_companyname,policy,UID_Number,SubGroup_Name,Emirates_Of_Visa,Work_Location,Entity_Id,Entity_Type,Establishment_Id,photo,Visa,passport_copy,Emirates_id_copy,medical_card,other_documents,Rid,Sid,PhoneNumber,Email,other_field_1,other_field_2,other_field_3")] entrymodel entryModel, HttpPostedFileBase photo, HttpPostedFileBase visa, HttpPostedFileBase medical_card, HttpPostedFileBase emirates_id_copy, HttpPostedFileBase passport_copy, HttpPostedFileBase other_documents)
        {
            if (ModelState.IsValid)
            {

                if (photo != null && photo.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(photo.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_photo" + System.IO.Path.GetExtension(photo.FileName));
                    photo.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = newpath;
                    entryModel.photo = imagepath;

                }
               
                if (visa != null && visa.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(visa.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_visa" + System.IO.Path.GetExtension(visa.FileName));

                    visa.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = newpath;
                    entryModel.Visa = imagepath;

                }
              
                if (passport_copy != null && passport_copy.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(passport_copy.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_passport" + System.IO.Path.GetExtension(passport_copy.FileName));

                    passport_copy.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = newpath;
                    entryModel.passport_copy = imagepath;

                }
                
                if (medical_card != null && medical_card.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(medical_card.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_medicalcard" + System.IO.Path.GetExtension(medical_card.FileName));

                    medical_card.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = newpath;
                    entryModel.medical_card = imagepath;

                }
              
                if (emirates_id_copy != null && emirates_id_copy.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(emirates_id_copy.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_emiratesid" + System.IO.Path.GetExtension(emirates_id_copy.FileName));

                    emirates_id_copy.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = newpath;
                    entryModel.Emirates_id_copy = imagepath;

                }
               
                if (other_documents != null && other_documents.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(other_documents.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath(String.Format("~/{0}", AppConstants.DocumentsFolder)), entryModel.Beneficiary_First_Name + "-" + entryModel.Beneficiary_Last_Name + "_other" + System.IO.Path.GetExtension(other_documents.FileName));

                    other_documents.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = newpath;
                    entryModel.other_documents = imagepath;

                }
               
               
                entryModel.Date_Time = GetIndianDateTime().ToString();
                db.Entry(entryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sid = new SelectList(db.grosssalaries, "Sid", "Value", entryModel.Sid);
            ViewBag.Rid = new SelectList(db.relationships, "Rid", "RelationName", entryModel.Rid);
            ViewBag.maritalstatus_id = new SelectList(db.marital_status, "maritalstatus_id", "Name", entryModel.maritalstatus_id);
            ViewBag.gender_id = new SelectList(db.genders, "gender_id", "Name", entryModel.gender_id);
            ViewBag.visacategory_id = new SelectList(db.visa_category, "visacategory_id", "Name", entryModel.visacategory_id);
            return View(entryModel);
        }
       
        // GET: EntryModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrymodel entryModel = db.entrymodels.Find(id);
            if (entryModel == null)
            {
                return HttpNotFound();
            }
            return View(entryModel);
        }

        // POST: EntryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            entrymodel entryModel = db.entrymodels.Find(id);
            db.entrymodels.Remove(entryModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "ExportToExcel")]
        public ActionResult ExportToExcel(int[] chkSelect)
        {
            GridView gv = new GridView();
            List<entrymodel> retData = db.entrymodels
            .Where(c => chkSelect.Contains(c.EntryId))
            .ToList();
            foreach (entrymodel e in retData)
            {
               // e.maritalstatus_id = e.marital_status.Name;

            }
            gv.AutoGenerateColumns = false;
            BoundField bf1 = new BoundField();
            bf1.DataField = "Beneficiary_First_Name";
            bf1.HeaderText = "Beneficiary First Name";
            gv.Columns.Add(bf1);
            BoundField bf2 = new BoundField();
            bf2.DataField = "Beneficiary_Middle_Name";
            bf2.HeaderText = "Beneficiary Middle Name";
            gv.Columns.Add(bf2);
            BoundField bf3 = new BoundField();
            bf3.DataField = "Beneficiary_Last_Name";
            bf3.HeaderText = "Beneficiary Last Name";
            gv.Columns.Add(bf3);
            BoundField bf4 = new BoundField();
            bf4.DataField = "Principal_First_Name";
            bf4.HeaderText = "Principal First Name";
            gv.Columns.Add(bf4);
            BoundField bf5 = new BoundField();
            bf5.DataField = "Principal_Middle_Name";
            bf5.HeaderText = "Principal Middle Name";
            gv.Columns.Add(bf5);
            BoundField bf6 = new BoundField();
            bf6.DataField = "Principal_Last_Name";
            bf6.HeaderText = "Principal Last Name";
            gv.Columns.Add(bf6);
            BoundField bf7 = new BoundField();
            bf7.DataField = "DOB";
            bf7.HeaderText = "Date Of Birth";
            gv.Columns.Add(bf7);
            BoundField bf8 = new BoundField();
            bf8.DataField = "marital_status.Name";
            bf8.HeaderText = "Marital Status";
            gv.Columns.Add(bf8);
            BoundField bf9 = new BoundField();
            bf9.DataField = "visa_category.Name";
            bf9.HeaderText = "Visa Category";
            gv.Columns.Add(bf9);
            BoundField bf10 = new BoundField();
            bf10.DataField = "Passport_Number";
            bf10.HeaderText = "Passport Number";
            gv.Columns.Add(bf10);
            BoundField bf11 = new BoundField();
            bf11.DataField = "Category";
            bf11.HeaderText = "Category";
            gv.Columns.Add(bf11);
            BoundField bf12 = new BoundField();
            bf12.DataField = "Nationality";
            bf12.HeaderText = "Nationality";
            gv.Columns.Add(bf12);
            BoundField bf13 = new BoundField();
            bf13.DataField = "gender.Name";
            bf13.HeaderText = "Gender";
            gv.Columns.Add(bf13);
            BoundField bf14 = new BoundField();
            bf14.DataField = "relationship.RelationName";
            bf14.HeaderText = "Relationship";
            gv.Columns.Add(bf14);
            BoundField bf15 = new BoundField();
            bf15.DataField = "grosssalary.Value";
            bf15.HeaderText = "Gross Salary";
            gv.Columns.Add(bf15);
            BoundField bf16 = new BoundField();
            bf16.DataField = "Emirates_Id";
            bf16.HeaderText = "Emirates Id";
            gv.Columns.Add(bf16);
            BoundField bf17 = new BoundField();
            bf17.DataField = "City_Of_Residence";
            bf17.HeaderText = "City Of Residence";
            gv.Columns.Add(bf17);
            BoundField bf18 = new BoundField();
            bf18.DataField = "Company_Name";
            bf18.HeaderText = "Company Name";
            gv.Columns.Add(bf18);
            BoundField bf19 = new BoundField();
            bf19.DataField = "UID_Number";
            bf19.HeaderText = "UID Number";
            gv.Columns.Add(bf19);
            BoundField bf20 = new BoundField();
            bf20.DataField = "SubGroup_Name";
            bf20.HeaderText = "SubGroup Name";
            gv.Columns.Add(bf20);
            BoundField bf21 = new BoundField();
            bf21.DataField = "Emirates_Of_Visa";
            bf21.HeaderText = "Emirates Of Visa";
            gv.Columns.Add(bf21);
            BoundField bf22 = new BoundField();
            bf22.DataField = "Work_Location";
            bf22.HeaderText = "Work Location";
            gv.Columns.Add(bf22);
            BoundField bf23 = new BoundField();
            bf23.DataField = "Entity_Id";
            bf23.HeaderText = "Entity Id";
            gv.Columns.Add(bf23);
            BoundField bf24 = new BoundField();
            bf24.DataField = "Entity_Type";
            bf24.HeaderText = "Entity Type";
            gv.Columns.Add(bf24);
            BoundField bf25 = new BoundField();
            bf25.DataField = "Establishment_Id";
            bf25.HeaderText = "Establishment Id";
            gv.Columns.Add(bf25);
            BoundField bf26 = new BoundField();
            bf26.DataField = "insurance_companyname";
            bf26.HeaderText = "Insurance Company Name";
            gv.Columns.Add(bf26);
            BoundField bf27 = new BoundField();
            bf27.DataField = "policy";
            bf27.HeaderText = "Policy Number";
            gv.Columns.Add(bf27);
            BoundField bf28 = new BoundField();
            bf28.DataField = "PhoneNumber";
            bf28.HeaderText = "Phone Number";
            gv.Columns.Add(bf28);
            BoundField bf29 = new BoundField();
            bf29.DataField = "Email";
            bf29.HeaderText = "Email";
            gv.Columns.Add(bf29);
            BoundField bf30 = new BoundField();
            bf30.DataField = "photo";
            bf30.HeaderText = "Photo";
            gv.Columns.Add(bf30);
            BoundField bf31 = new BoundField();
            bf31.DataField = "Visa";
            bf31.HeaderText = "Visa";
            gv.Columns.Add(bf31);
            BoundField bf32 = new BoundField();
            bf32.DataField = "passport_copy";
            bf32.HeaderText = "Passport Copy";
            gv.Columns.Add(bf32);
            BoundField bf33 = new BoundField();
            bf33.DataField = "Emirates_id_copy";
            bf33.HeaderText = "Emirates Id Copy";
            gv.Columns.Add(bf33);
            BoundField bf34 = new BoundField();
            bf34.DataField = "medical_card";
            bf34.HeaderText = "Medical Card";
            gv.Columns.Add(bf34);
            BoundField bf35 = new BoundField();
            bf35.DataField = "other_documents";
            bf35.HeaderText = "Other Documents";
            gv.Columns.Add(bf35);
            BoundField bf36 = new BoundField();
            bf36.DataField = "other_field_1";
            bf36.HeaderText = "Other Field 1";
            gv.Columns.Add(bf36);
            BoundField bf37 = new BoundField();
            bf37.DataField = "other_field_2";
            bf37.HeaderText = "Other Field 2";
            gv.Columns.Add(bf37);
            BoundField bf38 = new BoundField();
            bf38.DataField = "other_field_3";
            bf38.HeaderText = "Other Field 3";
            gv.Columns.Add(bf38);
           // gv.Columns.Add(new BoundField.DataField
            gv.DataSource = retData;
           gv.DataBind();
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                if (gv.HeaderRow.Cells[i].Text == "other_field_1")
                {
                    gv.HeaderRow.Cells[i].Text = medicaldb.other_field_1;
                }
                else if (gv.HeaderRow.Cells[i].Text == "other_field_2")
                {
                    gv.HeaderRow.Cells[i].Text = medicaldb.other_field_2;
                }
                else if (gv.HeaderRow.Cells[i].Text == "other_field_3")
                {
                    gv.HeaderRow.Cells[i].Text = medicaldb.other_field_3;
                }


            }
            //gv.Columns[gv.Columns.IndexOf(gv.Da)].HeaderText = medicaldb.other_field_1;
            Response.ClearContent();
            Response.BufferOutput = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=Medical_Db.xls");

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");

        }
        private List<string> PopulateFiles(int[] selectedRecords)
        {
            List<string> selectedfiles = new List<string>();
            try
            {
                List<entrymodel> entryData = db.entrymodels
                        .Where(c => selectedRecords.Contains(c.EntryId))
                    .ToList();
                //List<filedetail> serverfiles = db.filedetails.ToList();

                //Get the records for which files have to be added
                foreach (entrymodel model in entryData)
                {
                    if(!String.IsNullOrEmpty(model.photo))
                    {
                        selectedfiles.Add(model.photo);
                    }
                    if (!String.IsNullOrEmpty(model.Visa))
                    {
                        selectedfiles.Add(model.Visa);
                    }
                    if (!String.IsNullOrEmpty(model.passport_copy))
                    {
                        selectedfiles.Add(model.passport_copy);
                    }
                    if (!String.IsNullOrEmpty(model.Emirates_id_copy))
                    {
                        selectedfiles.Add(model.Emirates_id_copy);
                    }
                    if (!String.IsNullOrEmpty(model.medical_card))
                    {
                        selectedfiles.Add(model.medical_card);
                    }
                    if (!String.IsNullOrEmpty(model.other_documents))
                    {
                        selectedfiles.Add(model.other_documents);
                    }
                   
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }

            return selectedfiles;

        }
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "ExportToFolder")]
        //[DeleteFileAttribute]
        public ActionResult ExportToFolder(int[] chkSelect)
        {

            string archiveFolder = string.Empty;
            string tempFolder = string.Empty;
            string uploadFolder = string.Empty;
            string sheetsFolder = string.Empty;
            string excelFile = string.Empty;
            string archiveFile = string.Empty;
            string currentFolder = string.Empty;
            List<string> selectedfiles = PopulateFiles(chkSelect);
            string RandomId = Guid.NewGuid().ToString();
            try
            {
                if (!System.IO.Directory.Exists(Server.MapPath("~/archive")))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("/") + "\\archive");
                }
                if (!System.IO.Directory.Exists(Server.MapPath("~/temp")))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("/") + "\\temp");
                }
                archiveFolder = Server.MapPath("~/archive");//_" + RandomId + ".zip");
                tempFolder = Server.MapPath("~/temp");
                uploadFolder = Server.MapPath("~/"+AppConstants.DocumentsFolder);
                sheetsFolder = Server.MapPath("~/sheets");
                currentFolder = tempFolder + "\\" + RandomId;
                excelFile = currentFolder + "\\medicalDb.xls";
                archiveFile = archiveFolder + "\\" + RandomId + "_medicalDb.zip";

                if (!System.IO.Directory.Exists(currentFolder))
                {
                    System.IO.Directory.CreateDirectory(currentFolder);
                }

                foreach (string selectedFile in selectedfiles)
                {
                    try
                    {
                        System.IO.File.Copy(uploadFolder + "\\" + selectedFile, Path.Combine(currentFolder, Path.GetFileName(uploadFolder + "\\" + selectedFile)));

                    }
                    catch (Exception exp)
                    {
                        ViewBag.Error = exp.ToString();
                    }
                }

                List<entrymodel> entryData = db.entrymodels
                .Where(c => chkSelect.Contains(c.EntryId))
                .ToList();
                //foreach(entrymodel model in entryData)
                //{
                //    if(!String.IsNullOrEmpty(model.photo))
                //    {
                //        model.photo = string.Format("=HYPERLINK('{0}')", model.photo);
                //    }
                //    if (!String.IsNullOrEmpty(model.Visa))
                //    {
                //        model.Visa = string.Format("=HYPERLINK('{0}')", model.Visa);
                //    }
                //    if (!String.IsNullOrEmpty(model.passport_copy))
                //    {
                //        model.passport_copy = string.Format("=HYPERLINK('{0}')", model.passport_copy);
                //    }
                //    if (!String.IsNullOrEmpty(model.Emirates_id_copy))
                //    {
                //        model.Emirates_id_copy = string.Format("=HYPERLINK('{0}')", model.Emirates_id_copy);
                //    }
                //    if (!String.IsNullOrEmpty(model.medical_card))
                //    {
                //        model.medical_card = string.Format("=HYPERLINK('{0}')", model.medical_card);
                //    }
                //    if (!String.IsNullOrEmpty(model.other_documents))
                //    {
                //        model.other_documents = string.Format("=HYPERLINK('{0}')", model.other_documents);
                //    }
                //}
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        StreamWriter writer = System.IO.File.AppendText(excelFile);
                        GridView gv1 = new GridView();
                        gv1.AutoGenerateColumns = false;
                        BoundField bf1 = new BoundField();
                        bf1.DataField = "Beneficiary_First_Name";
                        bf1.HeaderText = "Beneficiary First Name";
                        gv1.Columns.Add(bf1);
                        BoundField bf2 = new BoundField();
                        bf2.DataField = "Beneficiary_Middle_Name";
                        bf2.HeaderText = "Beneficiary Middle Name";
                        gv1.Columns.Add(bf2);
                        BoundField bf3 = new BoundField();
                        bf3.DataField = "Beneficiary_Last_Name";
                        bf3.HeaderText = "Beneficiary Last Name";
                        gv1.Columns.Add(bf3);
                        BoundField bf4 = new BoundField();
                        bf4.DataField = "Principal_First_Name";
                        bf4.HeaderText = "Principal First Name";
                        gv1.Columns.Add(bf4);
                        BoundField bf5 = new BoundField();
                        bf5.DataField = "Principal_Middle_Name";
                        bf5.HeaderText = "Principal Middle Name";
                        gv1.Columns.Add(bf5);
                        BoundField bf6 = new BoundField();
                        bf6.DataField = "Principal_Last_Name";
                        bf6.HeaderText = "Principal Last Name";
                        gv1.Columns.Add(bf6);
                        BoundField bf7 = new BoundField();
                        bf7.DataField = "DOB";
                        bf7.HeaderText = "Date Of Birth";
                        gv1.Columns.Add(bf7);
                        BoundField bf8 = new BoundField();
                        bf8.DataField = "marital_status.Name";
                        bf8.HeaderText = "Marital Status";
                        gv1.Columns.Add(bf8);
                        BoundField bf9 = new BoundField();
                        bf9.DataField = "visa_category.Name";
                        bf9.HeaderText = "Visa Category";
                        gv1.Columns.Add(bf9);
                        BoundField bf10 = new BoundField();
                        bf10.DataField = "Passport_Number";
                        bf10.HeaderText = "Passport Number";
                        gv1.Columns.Add(bf10);
                        BoundField bf11 = new BoundField();
                        bf11.DataField = "Category";
                        bf11.HeaderText = "Category";
                        gv1.Columns.Add(bf11);
                        BoundField bf12 = new BoundField();
                        bf12.DataField = "Nationality";
                        bf12.HeaderText = "Nationality";
                        gv1.Columns.Add(bf12);
                        BoundField bf13 = new BoundField();
                        bf13.DataField = "gender.Name";
                        bf13.HeaderText = "Gender";
                        gv1.Columns.Add(bf13);
                        BoundField bf14 = new BoundField();
                        bf14.DataField = "relationship.RelationName";
                        bf14.HeaderText = "Relationship";
                        gv1.Columns.Add(bf14);
                        BoundField bf15 = new BoundField();
                        bf15.DataField = "grosssalary.Value";
                        bf15.HeaderText = "Gross Salary";
                        gv1.Columns.Add(bf15);
                        BoundField bf16 = new BoundField();
                        bf16.DataField = "Emirates_Id";
                        bf16.HeaderText = "Emirates Id";
                        gv1.Columns.Add(bf16);
                        BoundField bf17 = new BoundField();
                        bf17.DataField = "City_Of_Residence";
                        bf17.HeaderText = "City Of Residence";
                        gv1.Columns.Add(bf17);
                        BoundField bf18 = new BoundField();
                        bf18.DataField = "Company_Name";
                        bf18.HeaderText = "Company Name";
                        gv1.Columns.Add(bf18);
                        BoundField bf19 = new BoundField();
                        bf19.DataField = "UID_Number";
                        bf19.HeaderText = "UID Number";
                        gv1.Columns.Add(bf19);
                        BoundField bf20 = new BoundField();
                        bf20.DataField = "SubGroup_Name";
                        bf20.HeaderText = "SubGroup Name";
                        gv1.Columns.Add(bf20);
                        BoundField bf21 = new BoundField();
                        bf21.DataField = "Emirates_Of_Visa";
                        bf21.HeaderText = "Emirates Of Visa";
                        gv1.Columns.Add(bf21);
                        BoundField bf22 = new BoundField();
                        bf22.DataField = "Work_Location";
                        bf22.HeaderText = "Work Location";
                        gv1.Columns.Add(bf22);
                        BoundField bf23 = new BoundField();
                        bf23.DataField = "Entity_Id";
                        bf23.HeaderText = "Entity Id";
                        gv1.Columns.Add(bf23);
                        BoundField bf24 = new BoundField();
                        bf24.DataField = "Entity_Type";
                        bf24.HeaderText = "Entity Type";
                        gv1.Columns.Add(bf24);
                        BoundField bf25 = new BoundField();
                        bf25.DataField = "Establishment_Id";
                        bf25.HeaderText = "Establishment Id";
                        gv1.Columns.Add(bf25);
                        BoundField bf26 = new BoundField();
                        bf26.DataField = "insurance_companyname";
                        bf26.HeaderText = "Insurance Company Name";
                        gv1.Columns.Add(bf26);
                        BoundField bf27 = new BoundField();
                        bf27.DataField = "policy";
                        bf27.HeaderText = "Policy Number";
                        gv1.Columns.Add(bf27);
                        BoundField bf28 = new BoundField();
                        bf28.DataField = "PhoneNumber";
                        bf28.HeaderText = "Phone Number";
                        gv1.Columns.Add(bf28);
                        BoundField bf29 = new BoundField();
                        bf29.DataField = "Email";
                        bf29.HeaderText = "Email";
                        gv1.Columns.Add(bf29);
                        BoundField bf30 = new BoundField();
                        bf30.DataField = "photo";
                        bf30.HeaderText = "Photo";
                        gv1.Columns.Add(bf30);
                        BoundField bf31 = new BoundField();
                        bf31.DataField = "Visa";
                        bf31.HeaderText = "Visa";
                        gv1.Columns.Add(bf31);
                        BoundField bf32 = new BoundField();
                        bf32.DataField = "passport_copy";
                        bf32.HeaderText = "Passport Copy";
                        gv1.Columns.Add(bf32);
                        BoundField bf33 = new BoundField();
                        bf33.DataField = "Emirates_id_copy";
                        bf33.HeaderText = "Emirates Id Copy";
                        gv1.Columns.Add(bf33);
                        BoundField bf34 = new BoundField();
                        bf34.DataField = "medical_card";
                        bf34.HeaderText = "Medical Card";
                        gv1.Columns.Add(bf34);
                        BoundField bf35 = new BoundField();
                        bf35.DataField = "other_documents";
                        bf35.HeaderText = "Other Documents";
                        gv1.Columns.Add(bf35);
                        BoundField bf36 = new BoundField();
                        bf36.DataField = "other_field_1";
                        bf36.HeaderText = "Other Field 1";
                        gv1.Columns.Add(bf36);
                        BoundField bf37 = new BoundField();
                        bf37.DataField = "other_field_2";
                        bf37.HeaderText = "Other Field 2";
                        gv1.Columns.Add(bf37);
                        BoundField bf38 = new BoundField();
                        bf38.DataField = "other_field_3";
                        bf38.HeaderText = "Other Field 3";
                        gv1.Columns.Add(bf38);
                        gv1.DataSource = entryData;
                        gv1.DataBind();
                        gv1.RenderControl(hw);
                        writer.WriteLine(sw.ToString());
                        writer.Close();
                    }
                }
                ZipFile.CreateFromDirectory(currentFolder, archiveFile);
                Response.ContentType = "application/zip";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + RandomId + "_medicalDb.zip");
                Response.TransmitFile(archiveFile);
                //Response.Flush();
                //Response.Clear();           // Already have this
                //Response.ClearContent();    // Add this line
                //Response.ClearHeaders(); 

            }
            catch (Exception exp)
            {
                ViewBag.Error = exp.ToString();
            }

            finally
            {
                try
                {
                    System.IO.Directory.Delete(currentFolder, true);
                    //System.IO.File.Delete(archiveFile);
                }
                catch (Exception exp)
                {
                    ViewBag.Error = exp.ToString();
                }
                //Response.End();
            }

            return View("Index");
        }
        public DateTime GetIndianDateTime()
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            return indianTime;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
