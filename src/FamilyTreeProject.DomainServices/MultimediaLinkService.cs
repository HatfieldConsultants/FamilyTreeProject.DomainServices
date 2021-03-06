﻿//******************************************
//  Copyright (C) 2014-2015 Charles Nurse  *
//                                         *
//  Licensed under MIT License             *
//  (see included LICENSE)                 *
//                                         *
//******************************************

using FamilyTreeProject.Data;
using FamilyTreeProject.DomainServices.Common;

namespace FamilyTreeProject.DomainServices
{
    /// <summary>
    ///   The MultimediaLinkService provides a Facade to the MultimediaLink store,
    ///   allowing for additional business logic to be applied.
    /// </summary>
    public class MultimediaLinkService : EntityService<MultimediaLink>,  IMultimediaLinkService
    {
        /// <summary>
        /// Constructs an MultimediaLink Service to manage Multimedia Links
        /// </summary>
        /// <param name = "unitOfWork">The Unit Of Work to use to retrieve data</param>
        public MultimediaLinkService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
