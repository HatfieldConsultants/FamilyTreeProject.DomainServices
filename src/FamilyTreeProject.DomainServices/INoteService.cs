﻿//******************************************
//  Copyright (C) 2014-2015 Charles Nurse  *
//                                         *
//  Licensed under MIT License             *
//  (see included LICENSE)                 *
//                                         *
// *****************************************

using System;
using System.Collections.Generic;
using Naif.Core.Collections;

namespace FamilyTreeProject.DomainServices
{
    public interface INoteService
    {
        /// <summary>
        ///   Adds a note to the data store and sets the <see cref = "Note.Id" /> property
        ///   of <paramref name = "newNote" /> to the id of the new note.
        /// </summary>
        /// <param name = "newNote">The note to add to the data store.</param>
        void Add(Note newNote);

        /// <summary>
        ///   Deletes a note from the data store
        /// </summary>
        /// <remarks>
        ///   The delete operation takes effect immediately
        /// </remarks>
        /// <param name = "note">The note to delete</param>
        void Delete(Note note);

        /// <summary>
        ///   Retrieves a single Note
        /// </summary>
        /// <param name = "id">The Id of the Note to retrieve</param>
        /// <param name="treeId">The Id of the tree</param>
        /// <returns>A <see cref = "Note" /></returns>
        Note Get(int treeId, int id);

        /// <summary>
        /// Retrieves all the notes for a Tree
        /// </summary>
        /// <param name = "treeId">The Id of the Tree</param>
        /// <returns>A collection of <see cref = "Note" /> objects</returns>
        IEnumerable<Note> Get(int treeId);

        /// <summary>
        /// Gets a page of notes based on a predicate
        /// </summary>
        /// <param name="treeId">The Id of the tree</param>
        /// <param name="predicate">The predicate to use</param>
        /// <param name="pageIndex">The page index to return</param>
        /// <param name="pageSize">The page size</param>
        /// <returns>List of notes</returns>
        IPagedList<Note> Get(int treeId, Func<Note, bool> predicate, int pageIndex, int pageSize);

        /// <summary>
        ///   Updates a note in the data store.
        /// </summary>
        /// <param name = "note">The note to update in the data store.</param>
        void Update(Note note);
    }
}
