-- MySQL Script generated by MySQL Workbench
-- Fri Apr  5 16:26:10 2024
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema residencia_3_periodo
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema residencia_3_periodo
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `residencia_3_periodo` DEFAULT CHARACTER SET utf8 ;
USE `residencia_3_periodo` ;

-- -----------------------------------------------------
-- Table `residencia_3_periodo`.`Livro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `residencia_3_periodo`.`Livro` (
  `idLivro` INT NOT NULL,
  `Título` VARCHAR(45) NOT NULL,
  `Ano_Public` DATETIME NOT NULL,
  `Valor` DECIMAL NOT NULL,
  `Autor` VARCHAR(45) NOT NULL,
  `Editora` VARCHAR(45) NOT NULL,
  `Quantidade` INT NOT NULL,
  `Gênero` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idLivro`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `residencia_3_periodo`.`Usuário`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `residencia_3_periodo`.`Usuário` (
  `idUsuário` INT NOT NULL,
  `Nome` VARCHAR(45) NOT NULL,
  `e-mail` VARCHAR(150) NOT NULL,
  `Endereço` VARCHAR(45) NULL,
  `Telefone` INT NOT NULL,
  PRIMARY KEY (`idUsuário`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `residencia_3_periodo`.`Funcionário`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `residencia_3_periodo`.`Funcionário` (
  `idFuncionário` INT NOT NULL,
  `Nome` VARCHAR(45) NULL,
  `e-mail` VARCHAR(150) NULL,
  `Telefone` INT NULL,
  `Endereço` VARCHAR(45) NULL,
  PRIMARY KEY (`idFuncionário`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `residencia_3_periodo`.`Empréstimo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `residencia_3_periodo`.`Empréstimo` (
  `idEmpréstimo` INT NOT NULL,
  `Usuário_idUsuário` INT NOT NULL,
  `Livro_idLivro` INT NOT NULL,
  `Data_Emp` DATETIME NOT NULL,
  `Data_Dev` DATETIME NOT NULL,
  PRIMARY KEY (`idEmpréstimo`, `Usuário_idUsuário`, `Livro_idLivro`),
  INDEX `fk_Empréstimo_Usuário1_idx` (`Usuário_idUsuário` ASC) VISIBLE,
  INDEX `fk_Empréstimo_Livro1_idx` (`Livro_idLivro` ASC) VISIBLE,
  CONSTRAINT `fk_Empréstimo_Usuário1`
    FOREIGN KEY (`Usuário_idUsuário`)
    REFERENCES `residencia_3_periodo`.`Usuário` (`idUsuário`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Empréstimo_Livro1`
    FOREIGN KEY (`Livro_idLivro`)
    REFERENCES `residencia_3_periodo`.`Livro` (`idLivro`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `residencia_3_periodo`.`Multa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `residencia_3_periodo`.`Multa` (
  `Usuário_idUsuário` INT NOT NULL,
  `Empréstimo_idEmpréstimo` INT NOT NULL,
  `Dias_Atraso` INT NOT NULL,
  `Valor` INT NOT NULL,
  PRIMARY KEY (`Usuário_idUsuário`, `Empréstimo_idEmpréstimo`),
  INDEX `fk_Multa_Usuário1_idx` (`Usuário_idUsuário` ASC) VISIBLE,
  CONSTRAINT `fk_Multa_Empréstimo`
    FOREIGN KEY (`Empréstimo_idEmpréstimo`)
    REFERENCES `residencia_3_periodo`.`Empréstimo` (`idEmpréstimo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Multa_Usuário1`
    FOREIGN KEY (`Usuário_idUsuário`)
    REFERENCES `residencia_3_periodo`.`Usuário` (`idUsuário`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `residencia_3_periodo`.`Usuário_has_Multa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `residencia_3_periodo`.`Usuário_has_Multa` (
  `Usuário_idUsuário` INT NOT NULL,
  `Multa_Usuário_idUsuário` INT NOT NULL,
  `Multa_Empréstimo_idEmpréstimo` INT NOT NULL,
  `Qntd_Multas` INT NOT NULL,
  PRIMARY KEY (`Usuário_idUsuário`, `Multa_Usuário_idUsuário`, `Multa_Empréstimo_idEmpréstimo`),
  INDEX `fk_Usuário_has_Multa_Multa1_idx` (`Multa_Usuário_idUsuário` ASC, `Multa_Empréstimo_idEmpréstimo` ASC) VISIBLE,
  INDEX `fk_Usuário_has_Multa_Usuário1_idx` (`Usuário_idUsuário` ASC) VISIBLE,
  CONSTRAINT `fk_Usuário_has_Multa_Usuário1`
    FOREIGN KEY (`Usuário_idUsuário`)
    REFERENCES `residencia_3_periodo`.`Usuário` (`idUsuário`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Usuário_has_Multa_Multa1`
    FOREIGN KEY (`Multa_Usuário_idUsuário` , `Multa_Empréstimo_idEmpréstimo`)
    REFERENCES `residencia_3_periodo`.`Multa` (`Usuário_idUsuário` , `Empréstimo_idEmpréstimo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
