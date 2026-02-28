export default function CalendarDay({ data, onClick }) {

    if (data.outsideMonth)
        return (
            <div
                style={{
                    background: "#eee",
                    height: 100,
                    width: 100,
                    color: "#999"
                }}
            >
                {data.day}
            </div>
        );
    const today = new Date().toISOString().split("T")[0];

    const isToday = today === data.date;

    return (
        <div
            onClick={() => onClick(data.date)}
            style={{
                height: 100,
                width: 100,
                border: "1px solid gray",
                cursor: "pointer",
                padding: 4,
                outline: isToday
                    ? "3px solid red"
                    : "none"
            }}
        >
            <div><b>{data.day}</b></div>

            {data.exercises?.slice(0, 3).map((ex, i) => (
                <div key={i} style={{ fontSize: 12 }}>
                    {ex.name} {ex.progressValue} {ex.unit}
                </div>
            ))}
        </div>
    );
}