CREATE DATABASE IF NOT EXISTS escola_de_musica;
USE escola_de_musica;

--  DROP DATABASE escola_de_musica;

CREATE TABLE responsavel_aluno (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cpf VARCHAR(11) NOT NULL UNIQUE,
    rg VARCHAR(20) NOT NULL UNIQUE,
    nome VARCHAR(150) NOT NULL,
    email VARCHAR(100),
    telefone VARCHAR(20) NOT NULL,
    data_nascimento DATE NOT NULL,
    parentesco ENUM('Pai', 'Mae', 'Avo', 'Tio', 'Tia', 'Patrocinador', 'Outro') NOT NULL
); 
CREATE TABLE aluno (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cpf VARCHAR(11) NOT NULL UNIQUE,
    rg VARCHAR(20) NOT NULL UNIQUE,
    nome VARCHAR(150) NOT NULL,
    email VARCHAR(100),
    telefone VARCHAR(20),
    data_nascimento DATE NOT NULL,
    fk_id_responsavel INT,
    data_matricula DATE NOT NULL,
    status_aluno ENUM('Ativo', 'Inativo') DEFAULT 'Ativo',
    FOREIGN KEY (fk_id_responsavel) REFERENCES responsavel_aluno(id) ON DELETE RESTRICT ON UPDATE CASCADE    
); 
CREATE TABLE professor (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    cpf VARCHAR(11) NOT NULL UNIQUE,
    rg VARCHAR(20) NOT NULL UNIQUE,
    email VARCHAR(100),
    telefone VARCHAR(20) NOT NULL,
    data_admissao DATE NOT NULL,
    data_demissao DATE,
    status_prof ENUM('Ativo', 'Inativo') DEFAULT 'Ativo',
    especialidade VARCHAR(100) NOT NULL,
    valor_hora_aula DECIMAL(10, 2) NOT NULL    
);
CREATE TABLE curso (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL UNIQUE,
    descricao TEXT,
    instrumento VARCHAR(100) NOT NULL,
    nivel ENUM('Iniciante', 'Intermediario', 'Avancado') NOT NULL,
    carga_horaria INT NOT NULL,
    duracao_meses INT NOT NULL
);
CREATE TABLE sala (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL UNIQUE,
    equipamentos TEXT,
    capacidade INT NOT NULL
);
CREATE TABLE turma (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    fk_curso INT NOT NULL,
    fk_sala INT NOT NULL,
    status_turma ENUM('Ativa', 'Inativa', 'EmAndamento', 'Concluida') DEFAULT 'Ativa',
    dia_semana ENUM('SegundaFeira', 'TerçaFeira', 'QuartaFeira', 
    'QuintaFeira', 'SextaFeira', 'Sabado', 'Domingo') NOT NULL,
    horario_inicio TIME NOT NULL,
    horario_fim TIME NOT NULL,
    capacidade INT NOT NULL,
    quantidade_aulas INT NOT NULL,
    data_inicio DATE NOT NULL,
    data_fim DATE,
	FOREIGN KEY (fk_curso) REFERENCES curso(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	FOREIGN KEY (fk_sala) REFERENCES sala(id) ON DELETE RESTRICT ON UPDATE CASCADE
);
CREATE TABLE disponibilidade_professor (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fk_professor_id INT NOT NULL,
    dia_semana ENUM('SegundaFeira', 'TerçaFeira', 'QuartaFeira', 
    'QuintaFeira', 'SextaFeira', 'Sabado', 'Domingo') NOT NULL,
    horario_inicio TIME NOT NULL,
    horario_fim TIME NOT NULL,
    status_disp ENUM('Disponivel', 'Indisponivel', 'Bloqueado') DEFAULT 'Disponivel',
    FOREIGN KEY (fk_professor_id) REFERENCES professor(id) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE ministra (
    fk_turma_id INT NOT NULL,
    fk_professor_id INT NOT NULL,
    data_atribuicao DATE NOT NULL,      
    PRIMARY KEY (fk_turma_id, fk_professor_id),
    FOREIGN KEY (fk_turma_id) REFERENCES turma(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (fk_professor_id) REFERENCES professor(id) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE agenda (
    fk_aluno_id INT NOT NULL,
    fk_turma_id INT NOT NULL,
    frequencia INT DEFAULT 0,
    status_agenda ENUM('Matriculado', 'Cancelado', 'Suspenso', 'Concluido') DEFAULT 'Matriculado',
    data_inscricao DATE NOT NULL,
    data_cancelamento DATE,    
    PRIMARY KEY (fk_aluno_id, fk_turma_id),
    FOREIGN KEY (fk_aluno_id) REFERENCES aluno(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (fk_turma_id) REFERENCES turma(id) ON DELETE CASCADE ON UPDATE CASCADE    
);
CREATE TABLE contrato (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fk_aluno_id INT NOT NULL,
    fk_curso_id INT NOT NULL,
    data_inicio DATE NOT NULL,
    data_fim DATE,
    data_vencimento_parcela DATE,
    valor_mensal DECIMAL(10, 2) NOT NULL,
    status_contrato ENUM('Ativo', 'Cancelado', 'Encerrado', 'Suspenso') DEFAULT 'Ativo',
    FOREIGN KEY (fk_aluno_id) REFERENCES aluno(id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (fk_curso_id) REFERENCES curso(id) ON DELETE RESTRICT ON UPDATE CASCADE 
);

