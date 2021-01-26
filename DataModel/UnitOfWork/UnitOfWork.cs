#region Using Namespaces...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataModel.GenericRepository;
#endregion
namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...
        private bmwEntities _context = null;

        private GenericRepository<CategoryMaster> _CategoryMasterRepository;
        private GenericRepository<ItemMaster> _ItemMasterRepository;
        private GenericRepository<SubCategoryMaster> _SubCategoryMasterRepository;
        private GenericRepository<OrderMaster> _OrderMasterRepository;
        #endregion
        public UnitOfWork()
        {
            _context = new bmwEntities();
        }
        public GenericRepository<CategoryMaster> CategoryMasterRepository
        {
            get
            {
                if (this._CategoryMasterRepository == null)
                    this._CategoryMasterRepository = new GenericRepository<CategoryMaster>(_context);
                return _CategoryMasterRepository;
            }
        }
        public GenericRepository<ItemMaster> ItemMasterRepository
        {
            get
            {
                if (this._ItemMasterRepository == null)
                    this._ItemMasterRepository = new GenericRepository<ItemMaster>(_context);
                return _ItemMasterRepository;
            }
        }
        public GenericRepository<SubCategoryMaster> SubCategoryMasterRepository
        {
            get
            {
                if (this._SubCategoryMasterRepository == null)
                    this._SubCategoryMasterRepository = new GenericRepository<SubCategoryMaster>(_context);
                return _SubCategoryMasterRepository;
            }
        }
        public GenericRepository<OrderMaster> OrderMasterRepository
        {
            get
            {
                if (this._OrderMasterRepository == null)
                    this._OrderMasterRepository = new GenericRepository<OrderMaster>(_context);
                return _OrderMasterRepository;
            }
        }
        #region Public Repository Creation properties...
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>



        #endregion
        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);
                throw e;
            }
        }
        #endregion
        #region Implementing IDiosposable...
        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion
        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}