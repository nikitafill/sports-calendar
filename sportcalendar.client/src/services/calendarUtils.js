export function buildCalendar(year, month, apiDays) {

    const firstDay = new Date(year, month, 1);
    const lastDay = new Date(year, month + 1, 0);

    const startWeekDay =
        (firstDay.getDay() + 6) % 7; // Monday start

    const days = [];

    // быстрый поиск упражнений
    const map = {};
    apiDays.forEach(d => {
        map[d.date] = d.exercises;
    });

    // пустые дни
    for (let i = 0; i < startWeekDay; i++) {
        days.push({ empty: true });
    }

    // дни месяца
    for (let d = 1; d <= lastDay.getDate(); d++) {

        const date =
            `${year}-${String(month + 1).padStart(2, "0")}-${String(d).padStart(2, "0")}`;

        days.push({
            day: d,
            date,
            exercises: map[date] || [],
            empty: false
        });
    }

    return days;
}