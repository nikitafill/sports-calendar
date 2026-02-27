import { useState, useEffect } from "react";
import CalendarHeader from "../components/CalendarHeader";
import CalendarGrid from "../components/CalendarGrid";
import DayDashboardModal from "../components/DayDashboardModal";
import { getMonthDays } from "../services/api";

export default function CalendarPage() {

    const today = new Date();

    const [currentDate, setCurrentDate] = useState(
        new Date(today.getFullYear(), today.getMonth(), 1)
    );

    const [activeDays, setActiveDays] = useState([]);
    const [selectedDay, setSelectedDay] = useState(null);

    useEffect(() => {
        loadMonth();
    }, [currentDate]);

    async function loadMonth() {
        const data = await getMonthDays(
            currentDate.getFullYear(),
            currentDate.getMonth() + 1
        );

        setActiveDays(data);
    }

    return (
        <div>
            <CalendarHeader
                date={currentDate}
                setDate={setCurrentDate}
            />

            <CalendarGrid
                date={currentDate}
                activeDays={activeDays}
                onDayClick={setSelectedDay}
            />

            {selectedDay && (
                <DayDashboardModal
                    date={selectedDay}
                    onClose={() => setSelectedDay(null)}
                    onChanged={loadMonth}
                />
            )}
        </div>
    );
}