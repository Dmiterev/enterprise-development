import logo from './logo.svg';
import './App.css';
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import EmployerCreate from './components/EmployerCreate';
import EmployerList from './components/EmployerList';
import EmployerUpdate from './components/EmployerUpdate';
import EmployerDelete from './components/EmployerDelete';

function App() {
  return (
    <Router>
      <div>
        <h1 class="text-center">Employers Client</h1>
        <Routes>
          <Route path="/" element={<EmployerList />} />
          <Route path="/employer/create" element={<EmployerCreate />} />
          <Route path="/employer/update/:id" element={<EmployerUpdate />} />
          <Route path="/employer/delete/:id" element={<EmployerDelete />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
