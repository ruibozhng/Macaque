using Macaque.Base.BusinessEntity;
using Macaque.Base.BusinessEntity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessComponent
{
    public abstract class BusinessComponentBase
    {
        internal string CurrentUserID
        {
            get
            {
                return "";// ApplicationContext.Current.UserId;
            }
        }

        public void UpdateCommonFields(DBEntityBase entity, UpdateActionType actionType)
        {
            UpdateCommonFields(entity, actionType, CurrentUserID);
        }

        public void UpdateCommonFields(DBEntityBase entity, UpdateActionType actionType, string userId)
        {
            switch (actionType)
            {
                case UpdateActionType.Add:
                    entity.CreatedBy = userId;
                    entity.CreatedDate = DateTime.Now;
                    entity.UpdatedBy = userId;
                    entity.UpdatedDate = DateTime.Now;
                    entity.IsDeleted = false;
                    entity.VersionNumber = 1;
                    break;

                case UpdateActionType.Update:
                    entity.UpdatedBy = userId;
                    entity.UpdatedDate = DateTime.Now;
                    entity.VersionNumber += 1;
                    break;

                case UpdateActionType.Delete:
                    entity.IsDeleted = true;
                    entity.UpdatedBy = userId;
                    entity.UpdatedDate = DateTime.Now;
                    entity.VersionNumber += 1;
                    break;
            }
        }
    }
}
