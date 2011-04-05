CREATE TABLE TeAjudo.Tarefa(
	IdTarefa uniqueidentifier default newid() primary key,
	Titulo nvarchar(100),
	Descricao nvarchar(1000)
);
