export default function CalendarHeader({ date, setDate }) {

    function prevMonth() {
        setDate(new Date(date.getFullYear(), date.getMonth() - 1, 1));
    }

    function nextMonth() {
        setDate(new Date(date.getFullYear(), date.getMonth() + 1, 1));
    }
    return (
        <div
            style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                gap: 20,
                marginBottom: 20
            }}
        >
            <button onClick={prevMonth}>Previous</button>

            <h2 style={{ minWidth: 220, textAlign: "center" }}>
                {date.toLocaleString("en-US", {
                    month: "long",
                    year: "numeric"
                })}
            </h2>

            <button onClick={nextMonth}>Next</button>
        </div>
    );
    /*return (
        <div style={{ display: "flex", gap: 20 }}>
            <button onClick={prevMonth}>Previous</button>

            <h2>
                {date.toLocaleString("default", {
                    month: "long",
                    year: "numeric"
                })}
            </h2>

            <button onClick={nextMonth}>Next</button>
        </div>
    );*/
}