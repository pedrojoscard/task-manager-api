import { useEffect, useState } from "react";
import { getTasks, createTask } from "../services/api";

function TaskList() {
    const [tasks, setTasks] = useState([]);
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");

    useEffect(() => {
        loadTasks();
    }, []);

    const loadTasks = async () => {
        const response = await getTasks();
        setTasks(response.data);
    };

    const handleCreate = async () => {
        await createTask({
            title,
            description,
        });

        setTitle("");
        setDescription("");

        loadTasks(); // recarrega lista
    };

    return (
        <div>
            <h2>Lista de Tarefas</h2>

            <div>
                <h3>Nova Tarefa</h3>
                <input
                    placeholder="Título"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                />
                <input
                    placeholder="Descrição"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                />
                <button onClick={handleCreate}>Criar</button>
            </div>

            <hr />

            {tasks.map((task) => (
                <div key={task.id}>
                    <p><strong>{task.title}</strong></p>
                    <p>{task.description}</p>
                    <p>Status: {task.status}</p>
                    <hr />
                </div>
            ))}
        </div>
    );
}

export default TaskList;