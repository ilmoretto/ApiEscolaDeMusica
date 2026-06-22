USE escola_de_musica;

-- 0. Inserir Usuarios (Autenticação)
INSERT INTO usuario (login, senha, role) VALUES 
('admin', 'admin', 'Administrador'),
('secretaria', 'secretaria', 'Secretaria');

-- 1. Inserir Responsaveis
INSERT INTO responsavel_aluno (cpf, rg, nome, email, telefone, data_nascimento, parentesco) VALUES 
('11111111111', '1111111', 'Carlos Silva', 'carlos@email.com', '11999999991', '1980-05-10', 'Pai'),
('22222222222', '2222222', 'Maria Oliveira', 'maria@email.com', '11999999992', '1982-08-15', 'Mae'),
('33333333333', '3333333', 'Roberto Santos', 'roberto@email.com', '11999999993', '1975-12-01', 'Tio'),
('44444444444', '4444444', 'Ana Lima', 'ana@email.com', '11999999994', '1990-03-20', 'Tia'),
('55555555555', '5555555', 'José Costa', 'jose@email.com', '11999999995', '1965-07-30', 'Avo');

-- 2. Inserir Alunos
INSERT INTO aluno (cpf, rg, nome, email, telefone, data_nascimento, responsavel_id, data_matricula, status_aluno) VALUES 
('10101010101', '1010101', 'João Silva', 'joao.silva@email.com', '11988888881', '2010-02-15', 1, '2023-01-10', 'Ativo'),
('20202020202', '2020202', 'Pedro Oliveira', 'pedro.oliveira@email.com', '11988888882', '2011-04-22', 2, '2023-02-15', 'Ativo'),
('30303030303', '3030303', 'Lucas Santos', 'lucas.santos@email.com', '11988888883', '2009-11-05', 3, '2023-03-20', 'Inativo'),
('40404040404', '4040404', 'Mariana Lima', 'mariana.lima@email.com', '11988888884', '2012-01-30', 4, '2023-04-25', 'Ativo'),
('50505050505', '5050505', 'Fernanda Costa', 'fernanda.costa@email.com', '11988888885', '2008-09-12', 5, '2023-05-10', 'Ativo');

-- 3. Inserir Professores
INSERT INTO professor (nome, cpf, rg, email, telefone, data_admissao, data_demissao, status_prof, especialidade, valor_hora_aula) VALUES 
('Maestro Antonio', '60606060606', '6060606', 'antonio@escola.com', '11977777771', '2020-02-01', NULL, 'Ativo', 'Violino e Viola', 60.00),
('Professora Beatriz', '70707070707', '7070707', 'beatriz@escola.com', '11977777772', '2021-03-15', NULL, 'Ativo', 'Piano Clássico', 75.00),
('Professor Carlos', '80808080808', '8080808', 'carlos.prof@escola.com', '11977777773', '2019-08-10', '2022-12-30', 'Inativo', 'Violão Popular', 50.00),
('Professora Daniela', '90909090909', '9090909', 'daniela@escola.com', '11977777774', '2022-01-20', NULL, 'Ativo', 'Canto Lírico', 80.00),
('Professor Eduardo', '01010101010', '0101010', 'eduardo@escola.com', '11977777775', '2023-05-05', NULL, 'Ativo', 'Bateria e Percussão', 55.00);

-- 4. Inserir Cursos
INSERT INTO curso (nome, descricao, instrumento, nivel, carga_horaria, duracao_meses) VALUES 
('Violino Básico', 'Introdução ao violino, postura e escalas iniciais.', 'Violino', 'Iniciante', 80, 12),
('Piano Intermediário', 'Leitura de partituras complexas e peças de nível médio.', 'Piano', 'Intermediario', 120, 18),
('Violão para Iniciantes', 'Acordes básicos, dedilhados e repertório popular.', 'Violão', 'Iniciante', 60, 6),
('Canto Avançado', 'Técnicas vocais avançadas e performance de palco.', 'Voz', 'Avancado', 160, 24),
('Bateria Ritmos', 'Estudo de ritmos brasileiros e jazz na bateria.', 'Bateria', 'Intermediario', 100, 12);

-- 5. Inserir Salas
INSERT INTO sala (nome, localizacao, equipamentos, capacidade) VALUES 
('Sala Beethoven', 'Bloco A - Térreo', 'Piano de Cauda, Estantes de Partitura, Espelhos', 15),
('Sala Mozart', 'Bloco A - 1º Andar', 'Teclados, Lousa, Sistema de Som', 20),
('Sala Villa-Lobos', 'Bloco B - Térreo', 'Violões, Cadeiras com braço', 12),
('Estúdio 1', 'Subsolo', 'Bateria Acústica, Amplificadores, Tratamento Acústico', 5),
('Sala Chopin', 'Bloco B - 1º Andar', 'Piano Vertical, Microfones', 10);

-- 6. Inserir Turmas
INSERT INTO turma (nome, curso_id, sala_id, status_turma, dia_semana, horario_inicio, horario_fim, capacidade, quantidade_aulas, data_inicio, data_fim) VALUES 
('Turma Violino 01', 1, 2, 'Ativa', 'SegundaFeira', '14:00:00', '16:00:00', 10, 40, '2024-02-01', '2025-02-01'),
('Turma Piano Int', 2, 1, 'Ativa', 'TercaFeira', '16:00:00', '18:00:00', 5, 60, '2024-03-01', '2025-09-01'),
('Turma Violão Sabado', 3, 3, 'EmAndamento', 'Sabado', '09:00:00', '11:00:00', 12, 20, '2024-01-15', '2024-07-15'),
('Turma Canto Noturno', 4, 5, 'Ativa', 'QuartaFeira', '19:00:00', '21:00:00', 8, 80, '2024-02-10', '2026-02-10'),
('Turma Bateria 01', 5, 4, 'Inativa', 'QuintaFeira', '14:00:00', '16:00:00', 3, 50, '2022-01-01', '2023-01-01');

-- 7. Inserir Disponibilidade Professor
INSERT INTO disponibilidade_professor (professor_id, dia_semana, horario_inicio, horario_fim, status_disp) VALUES 
(1, 'SegundaFeira', '13:00:00', '18:00:00', 'Disponivel'),
(2, 'TercaFeira', '14:00:00', '20:00:00', 'Disponivel'),
(3, 'Sabado', '08:00:00', '12:00:00', 'Indisponivel'),
(4, 'QuartaFeira', '18:00:00', '22:00:00', 'Disponivel'),
(5, 'QuintaFeira', '13:00:00', '17:00:00', 'Bloqueado');

-- 8. Inserir Ministras (Professor <-> Turma)
INSERT INTO ministra (turma_id, professor_id, data_atribuicao) VALUES 
(1, 1, '2024-01-20'),
(2, 2, '2024-02-15'),
(3, 3, '2024-01-10'),
(4, 4, '2024-02-05'),
(5, 5, '2021-12-15');

-- 9. Inserir Agendas (Aluno <-> Turma)
INSERT INTO agenda (aluno_id, turma_id, frequencia, status_agenda, data_inscricao, data_cancelamento) VALUES 
(1, 1, 95, 'Matriculado', '2024-01-25', NULL),
(2, 2, 100, 'Matriculado', '2024-02-20', NULL),
(3, 3, 50, 'Cancelado', '2024-01-10', '2024-03-01'),
(4, 4, 90, 'Matriculado', '2024-02-05', NULL),
(5, 5, 100, 'Concluido', '2022-01-05', NULL);

-- 10. Inserir Contratos
INSERT INTO contrato (aluno_id, curso_id, data_inicio, data_fim, data_vencimento, valor_mensal, status_contrato) VALUES 
(1, 1, '2024-02-01', '2025-02-01', '2024-03-10', 150.00, 'Ativo'),
(2, 2, '2024-03-01', '2025-09-01', '2024-04-15', 250.00, 'Ativo'),
(3, 3, '2024-01-15', '2024-07-15', '2024-02-05', 100.00, 'Cancelado'),
(4, 4, '2024-02-10', '2026-02-10', '2024-03-05', 300.00, 'Ativo'),
(5, 5, '2022-01-01', '2023-01-01', '2022-02-10', 200.00, 'Encerrado');
