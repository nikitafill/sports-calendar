import { useEffect, useState } from "react";
import {
    getExercisesByDate,
    deleteExercise,
    updateStatus,
    createExercise,
    getExerciseTypes
} from "../services/api";

export default function DayDashboardModal({
    date,
    onClose,
    onChanged
}) {

    const [exercises, setExercises] = useState([]);
    const [types, setTypes] = useState([]);
    const [typeId, setTypeId] = useState("");
    const [progress, setProgress] = useState("");

    useEffect(() => {
        load();
        loadTypes();
    }, [date]);

    async function load() {
        const data = await getExercisesByDate(date);
        setExercises(data);
    }

    async function loadTypes() {
        const data = await getExerciseTypes();
        setTypes(data);
    }

    async function addExercise() {
        await createExercise({
            exerciseTypeId: Number(typeId),
            exerciseDate: date,
            progressValue: Number(progress)
        });

        setProgress("");
        await load();
        onChanged(); 
    }

    async function changeStatus(id, status) {
        await updateStatus(id, status);
        await load();
        onChanged();
    }

    async function remove(id) {
        await deleteExercise(id);
        await load();
        onChanged();
    }
    return (
        <div style={overlayStyle}>
            <div style={modalStyle}>
                <h3>{date}</h3>

                <div>
                    <select
                        value={typeId}
                        onChange={e => setTypeId(e.target.value)}
                    >
                        <option value="">Select exercise</option>
                        {types.map(t => (
                            <option key={t.id} value={t.id}>
                                {t.name}
                            </option>
                        ))}
                    </select>

                    <input
                        type="number"
                        placeholder="Progress"
                        value={progress}
                        onChange={e => setProgress(e.target.value)}
                    />

                    <button onClick={addExercise}>
                        Add
                    </button>
                </div>

                <hr />

                {exercises.map(e => (
                    <div key={e.id}>
                        {e.exerciseTypeName}
                        {" "}
                        {e.progressValue}
                        {" "}
                        {e.progressUnit}

                        <select
                            value={e.status}
                            onChange={(ev) =>
                                changeStatus(e.id, Number(ev.target.value))
                            }
                        >
                            <option value={0}>Planned</option>
                            <option value={1}>Done</option>
                            <option value={2}>Skipped</option>
                        </select>

                        <button
                            onClick={() => remove(e.id)}
                        >
                            Delete
                        </button>
                    </div>
                ))}

                <button onClick={onClose}>
                    Close
                </button>
            </div>
        </div>
    );
}

const overlayStyle = {
    position: "fixed",
    top: 0,
    left: 0,
    width: "100vw",
    height: "100vh",
    background: "rgba(0,0,0,0.4)",
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    zIndex: 1000
};

const modalStyle = {
    background: "white",
    padding: 20,
    borderRadius: 8,
    width: 500,
    maxHeight: "80vh",
    overflowY: "auto"
};