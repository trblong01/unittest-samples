package  domain.repositories;

import domain.entities.ClotheEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.UUID;

@Repository
public interface IRepository extends JpaRepository<ClotheEntity, UUID> {
    // Additional query methods can be defined here if needed.
}
