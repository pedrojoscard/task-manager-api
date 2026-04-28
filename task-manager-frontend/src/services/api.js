const API_URL = "https://localhost:7230/api/task";

export const getTasks = async () => {
    const response = await fetch(API_URL);
    const data = await response.json();
    return data;
};

export const createTask = async (task) => {
    const response = await fetch("https://localhost:7230/api/task", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(task),
    });

    return await response.json();
};