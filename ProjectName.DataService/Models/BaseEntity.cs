using System.ComponentModel.DataAnnotations;

namespace ProjectName.DataService.Models
{
    /// <summary>
    /// Base class for all entities, providing common properties like Id, CreatedAt, and UpdatedAt.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// The unique identifier for the entity.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The date and time when the entity was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The date and time when the entity was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Constructor for BaseEntity initializes CreatedAt to the current date and time.
        /// </summary>
        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
