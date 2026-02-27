const API_URL = "https://localhost:7182/api";

export async function getMonthDays(year, month) {
    const res = await fetch(
        `${API_URL}/exercises/month?year=${year}&month=${month}`
    );

    return await res.json();
}

export async function getExercisesByDate(date) {
    const res = await fetch(`${API_URL}/exercises/${date}`);
    return await res.json();
}

export async function createExercise(data) {
    await fetch(`${API_URL}/exercises`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });
}

export async function updateStatus(id, status) {
    await fetch(`${API_URL}/exercises/${id}/status`, {
        method: "PATCH",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ status })
    });
}

export async function deleteExercise(id) {
    await fetch(`${API_URL}/exercises/${id}`, {
        method: "DELETE"
    });
}
export async function getExerciseTypes() {
    const res = await fetch(`${API_URL}/exercise-types`);
    return await res.json();
}