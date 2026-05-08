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
    };

    return (
        <div>
            <div className="bg-white p-6 rounded-xl shadow-md mb-6">
                <h2 className="text-xl font-semibold mb-4">
                    Nova Tarefa
                </h2>

                <div className="flex flex-col md:flex-row gap-4">
                    <input
                        placeholder="Título"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        className="border border-gray-300 rounded-lg p-3 flex-1 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    />

                    <input
                        placeholder="Descrição"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        className="border border-gray-300 rounded-lg p-3 flex-1 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    />

                    <button
                        onClick={handleCreate}
                        className="bg-blue-600 hover:bg-blue-700 text-white px-6 py-3 rounded-lg font-medium transition"
                    >
                        Criar
                    </button>
                </div>
            </div>

            <div className="space-y-4">

                {tasks.length === 0 && (
                    <div className="bg-white p-10 rounded-xl shadow-md text-center text-gray-500">
                        Nenhuma tarefa cadastrada.
                    </div>
                )}

                {tasks.map((task) => (
                    <div
                        key={task.id}
                        className="bg-white p-5 rounded-xl shadow-md hover:shadow-lg transition"
                    >
                        <div className="flex justify-between items-center">
                            <div>
                                <h3 className="text-xl font-semibold text-gray-800">
                                    {task.title}
                                </h3>

                                <p className="text-gray-600 mt-2">
                                    {task.description}
                                </p>

                                <span
                                    className={`inline-block mt-3 px-3 py-1 text-sm rounded-full ${task.status === "Done"
                                            ? "bg-green-100 text-green-700"
                                            : task.status === "Doing"
                                                ? "bg-yellow-100 text-yellow-700"
                                                : "bg-gray-200 text-gray-700"
                                        }`}
                                >
                                    {task.status}
                                </span>
                            </div>

                            <div className="flex gap-2">
                                {task.status !== "Done" && (
                                    <button
                                        onClick={() => handleDone(task)}
                                        className="bg-green-600 hover:bg-green-700 text-white px-4 py-2 rounded-lg transition"
                                    >
                                        Concluir
                                    </button>
                                )}

                                <button
                                    onClick={() => handleDelete(task.id)}
                                    className="bg-red-600 hover:bg-red-700 text-white px-4 py-2 rounded-lg transition"
                                >
                                    Deletar
                                </button>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default TaskList;