// App.js
import { useState } from "react";
import { ThemeProvider } from "./components/theme-provider";
import Dashboard from "./pages/Dashboard";
import Login from "./pages/Login";
import { BrowserRouter, Route, Routes } from "react-router-dom";

function App() {
  const [count, setCount] = useState(0);

  return (
    <BrowserRouter>
      <ThemeProvider defaultTheme="dark" storageKey="vite-ui-theme">
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/dashboard/*" element={<Dashboard />} />
        </Routes>
      </ThemeProvider>
    </BrowserRouter>
  );
}

export default App;
