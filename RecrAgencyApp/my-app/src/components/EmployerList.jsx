import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import api from '../api/api';

const EmployerList = () => {
  const [employers, setEmployers] = useState([]);
  const [message, setMessage] = useState('');
  const [expandedEmployerId, setExpandedEmployerId] = useState(null); 

  const deleteEmployer = async (id) => {
    const confirmDelete = window.confirm("Are you sure you want to delete this employer?");
    if (!confirmDelete) return; 

    try {
      await api.delete(`/employer/${id}`);
      setEmployers(employers.filter((employer) => employer.id !== id));
      setMessage('Employer deleted successfully!');
      setTimeout(() => setMessage(''), 3000);
    } catch (error) {
      console.error('Error deleting employer:', error);
      setMessage('Failed to delete employer.');
      setTimeout(() => setMessage(''), 3000);
    }
  };

  const toggleExpand = (id) => {
    setExpandedEmployerId(expandedEmployerId === id ? null : id); 
  };

  useEffect(() => {
    const fetchEmployers = async () => {
      try {
        const response = await api.get('/employer');
        setEmployers(response.data);
      } catch (error) {
        console.error('Error fetching employers:', error);
        setMessage('Failed to fetch employers.');
        setTimeout(() => setMessage(''), 3000);
      }
    };
    fetchEmployers();
  }, []);

  return (
    <div className="container mt-5">
      <h2>Employer List</h2>
      {message && (
        <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
          {message}
        </div>
      )}
      <Link to="/employer/create" className="btn btn-success mb-3">Create New Employer</Link>
      <ul className="list-group">
        {employers.length > 0 ? (
          employers.map((employer) => (
            <li key={employer.id} className="list-group-item">
              <div className="d-flex justify-content-between align-items-center">
                <span>{employer.companyName}</span>
              </div>
              <button 
                className="btn btn-info btn-sm mt-2" 
                onClick={() => toggleExpand(employer.id)}
              >
                Информация
              </button>
              {expandedEmployerId === employer.id && (
                <div className="mt-2">
                  <p><strong>Contact Person:</strong> {employer.contactPerson}</p>
                  <p><strong>Phone:</strong> {employer.phone}</p>
                  <div className="mt-2">
                    <Link to={`/employer/update/${employer.id}`} className="btn btn-warning btn-sm me-2">Update</Link>
                    <button onClick={() => deleteEmployer(employer.id)} className="btn btn-danger btn-sm">Delete</button>
                  </div>
                </div>
              )}
            </li>
          ))
        ) : (
          <li className="list-group-item">No employers found.</li>
        )}
      </ul>
    </div>
  );
}

export default EmployerList;