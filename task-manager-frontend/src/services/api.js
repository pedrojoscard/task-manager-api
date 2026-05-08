const API_URL = "https://localhost:7230/api/task";

export const getTasks = async () => {
    const response = await fetch(API_URL);
    return await response.json();
};

export const createTask = async (task) => {
    const response = await fetch(API_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(task),
    });

    return await response.json();
};

export const deleteTask = async (id) => {
    await fetch(`${API_URL}/${id}`, {
        method: "DELETE",
    });
};

export const updateTask = async (id, task) => {
    const response = await fetch(`${API_URL}/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(task),
    });

    return await response.json();
};