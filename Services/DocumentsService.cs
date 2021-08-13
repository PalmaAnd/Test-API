using System;
using System.Collections.Generic;
using System.Linq;
using Test_API.Models;
using TodoApi.Models;

namespace DocumentsService.Services
{
    public class DocumentService
    {
        private readonly DocumentContext context;

        public DocumentService(DocumentContext context)
        {
            this.context = context;
        }

        public List<Documentitem> Get()
        {
            try{

                System.Diagnostics.Debug.WriteLine("GET ohne number");
                return context.Document.ToList();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("FEHLER INCOMING");
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        public Documentitem Get(long number)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("GET mit number");
                return context.Document.Where(document => document.Number == number).FirstOrDefault();
                
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("FEHLER INCOMING");
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }

        }


        public Documentitem Create(Documentitem document)
        {
            System.Diagnostics.Debug.WriteLine("POST");
            try
            {
            context.Document.Add(document);
            context.SaveChanges(true);
            return document;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("FEHLER INCOMING");
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        public void Update(Documentitem documentitem)
        {
            context.Document.Update(documentitem);
            context.SaveChanges(true);

        }

        public void Remove(long id)
        {
            //context.Document.Remove(documentitem);
        }

    }
}