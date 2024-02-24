using Sports_Admin_Core.Entities.BaseEntities;
using Sports_Admin_Core.Entities.Identity;

namespace Sports_Admin_Core.Entities
{
    public class FavoriteClubs : FullAuditedBaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Guid ClubId { get; set; }
        public Club Club { get; set; }
    }
}
