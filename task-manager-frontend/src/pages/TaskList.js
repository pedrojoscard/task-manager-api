import { useEffect, useState } from "react";
import { getTasks, createTask, deleteTask, updateTask } from "../services/api";

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

        loadTasks();
    };

    const handleDelete = async (id) => {
        await deleteTask(id);
        loadTasks();
    };

    const handleDone = async (task) => {
        await updateTask(task.id, {
            title: task.title,
            description: task.description,
            status: "Done",
        });

        loadTasks();
    }

    return (
        <div>
            <div
                style={{
                    marginBottom: "20px",
                    display: "flex",
                    gap: "10px",
                }}
            >
                <input
                    placeholder="Título"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    style={{
                        padding: "10px",
                        width: "200px",
                    }}
                />

                <input
                    placeholder="Descrição"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    style={{
                        padding: "10px",
                        width: "300px",
                    }}
                />

                <button onClick={handleCreate}>
                    Criar
                </button>
            </div>

            {tasks.map((task) => (
                <div
                    key={task.id}
                    style={{
                        border: "1px solid #ccc",
                        padding: "15px",
                        marginBottom: "10px",
                        borderRadius: "8px",
                    }}
                >
                    <h3>{task.title}</h3>

                    <p>{task.description}</p>

                    <p>
                        <strong>Status:</strong> {task.status}
                    </p>

                    <div style={{ display: "flex", gap: "10px" }}>
                        <button onClick={() => handleDone(task)}>
                            Concluir
                        </button>

                        <button onClick={() => handleDelete(task.id)}>
                            Deletar
                        </button>
                    </div>
                </div>
            ))}
        </div>
    )
};

export default TaskList;