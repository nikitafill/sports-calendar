import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
import CalendarPage from './pages/CalendarPage.jsx'
createRoot(document.getElementById('root')).render(
  <StrictMode>
    <CalendarPage />
  </StrictMode>,
)
//<App />