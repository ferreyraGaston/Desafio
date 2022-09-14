-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Revista_Suscripcion
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Revista_Suscripcion
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Revista_Suscripcion` DEFAULT CHARACTER SET utf8 ;
USE `Revista_Suscripcion` ;

-- -----------------------------------------------------
-- Table `Revista_Suscripcion`.`Tipodocumento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Revista_Suscripcion`.`Tipodocumento` (
  `idTipodocumento` INT NOT NULL AUTO_INCREMENT,
  `Documento` VARCHAR(45) NULL,
  PRIMARY KEY (`idTipodocumento`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Revista_Suscripcion`.`Suscriptor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Revista_Suscripcion`.`Suscriptor` (
  `idSuscriptor` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NULL,
  `Apellido` VARCHAR(45) NULL,
  `NumeroDocumento` VARCHAR(10) NULL,
  `TipoDocumento` INT NULL,
  `Direccion` VARCHAR(70) NULL,
  `Telefono` VARCHAR(45) NULL,
  `Email` VARCHAR(70) NULL,
  `NombreUsuario` VARCHAR(45) NULL,
  `Contrasena` VARCHAR(500) NULL,
  PRIMARY KEY (`idSuscriptor`),
  INDEX `Documentos_idx` (`TipoDocumento` ASC) VISIBLE,
  CONSTRAINT `Documentos`
    FOREIGN KEY (`TipoDocumento`)
    REFERENCES `Revista_Suscripcion`.`Tipodocumento` (`idTipodocumento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Revista_Suscripcion`.`Suscripcion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Revista_Suscripcion`.`Suscripcion` (
  `IdAsociacion` INT NOT NULL AUTO_INCREMENT,
  `FechaAlta` DATE NULL,
  `DechaFin` DATE NULL,
  `MotivoFin` VARCHAR(100) NULL,
  PRIMARY KEY (`IdAsociacion`),
  CONSTRAINT `suscripciones`
    FOREIGN KEY (`IdAsociacion`)
    REFERENCES `Revista_Suscripcion`.`Suscriptor` (`idSuscriptor`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
