import CalendarDay from "./CalendarDay";

export default function CalendarGrid({ date, activeDays, onDayClick })
{

    const year = date.getFullYear();
    const month = date.getMonth();

    const firstDay = new Date(year, month, 1);
    const startDay = firstDay.getDay() || 7;

    const daysInMonth = new Date(year, month + 1, 0).getDate();

    const exerciseMap = {};
    activeDays.forEach(d => {
        exerciseMap[d.date] = d.exercises;
    });

    const cells = [];

    for (let i = 1; i < startDay; i++) {
        cells.push({ empty: true });
    }

    for (let d = 1; d <= daysInMonth; d++) {

        const fullDate = `${year}-${String(month + 1).padStart(2, "0")}-${String(d).padStart(2, "0")}`;

        cells.push({
            day: d,
            date: fullDate,
            exercises: exerciseMap[fullDate] || [],
            empty: false
        });
    }

    return (
        <div
            style={{
                display: "grid",
                gridTemplateColumns: "repeat(7,1fr)",
                gap: 5
            }}
        >
            {cells.map((c, i) => (
                <CalendarDay key={i} data={c} onClick={onDayClick}/>
            ))}
        </div>
    );
}