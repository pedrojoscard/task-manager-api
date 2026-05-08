import TaskList from "./pages/TaskList";

function App() {
    return (
        <div className="min-h-screen bg-gray-100 flex justify-center p-10">
            <div className="w-full max-w-3xl">
                <h1 className="text-4xl font-bold text-center text-gray-800 mb-8">
                    Task Manager
                </h1>

                <TaskList />
            </div>
        </div>
    );
}

export default App;