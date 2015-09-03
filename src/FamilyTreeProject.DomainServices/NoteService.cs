﻿//******************************************
//  Copyright (C) 2014-2015 Charles Nurse  *
//                                         *
//  Licensed under MIT License             *
//  (see included LICENSE)                 *
//                                         *
// *****************************************

using System;
using System.Collections.Generic;
using System.Linq;
using Naif.Core.Collections;
using Naif.Core.Contracts;
using Naif.Data;

namespace FamilyTreeProject.DomainServices
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Note> _repository;

        /// <summary>
        ///   Constructs a Note Service that will use the specified
        ///   <see cref = "IUnitOfWork"></see>
        ///   to retrieve data
        /// </summary>
        /// <param name = "unitOfWork">The <see cref = "IUnitOfWork"></see>
        ///   to use to retrieve data</param>
        public NoteService(IUnitOfWork unitOfWork)
        {
            //Contract
            Requires.NotNull(unitOfWork);

            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Note>();
        }

        /// <summary>
        ///   Adds a note to the data store and sets the <see cref = "Note.Id" /> property
        ///   of <paramref name = "note" /> to the id of the new note.
        /// </summary>
        /// <param name = "note">The note to add to the data store.</param>
        public void Add(Note note)
        {
            //Contract
            Requires.NotNull(note);

            _repository.Add(note);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///   Deletes a note from the data store
        /// </summary>
        /// <remarks>
        ///   The delete operation takes effect immediately
        /// </remarks>
        /// <param name = "note">The note to delete</param>
        public void Delete(Note note)
        {
            //Contract
            Requires.NotNull(note);

            _repository.Delete(note);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///   Retrieves a single Note
        /// </summary>
        /// <param name = "id">The Id of the Note to retrieve</param>
        /// <param name="treeId">The Id of the tree</param>
        /// <returns>A <see cref = "Note" /></returns>
        public Note Get(int id, int treeId)
        {
            //Contract
            Requires.NotNegative("id", id);

            return Get(treeId).SingleOrDefault(n => n.Id == id);
        }

        /// <summary>
        /// Retrieves all the notes for a Tree
        /// </summary>
        /// <param name = "treeId">The Id of the Tree</param>
        /// <returns>A collection of <see cref = "Note" /> objects</returns>
        public IEnumerable<Note> Get(int treeId)
        {
            //Contract
            Requires.NotNegative("treeId", treeId);

            return _repository.Get(treeId);
        }

        /// <summary>
        /// Gets a page of notes based on a predicate
        /// </summary>
        /// <param name="treeId">The Id of the tree</param>
        /// <param name="predicate">The predicate to use</param>
        /// <param name="pageIndex">The page index to return</param>
        /// <param name="pageSize">The page size</param>
        /// <returns>List of notes</returns>
        public IPagedList<Note> Get(int treeId, Func<Note, bool> predicate, int pageIndex, int pageSize)
        {
            return new PagedList<Note>(Get(treeId).Where(predicate), pageIndex, pageSize);
        }

        /// <summary>
        ///   Updates a note in the data store.
        /// </summary>
        /// <param name = "note">The note to update in the data store.</param>
        public void Update(Note note)
        {
            //Contract
            Requires.NotNull(note);

            _repository.Update(note);
            _unitOfWork.Commit();
        }
    }
}
