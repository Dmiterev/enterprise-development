import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../api/api';

const EmployerCreate = () => {
  const [companyName, setCompanyName] = useState('');
  const [contactPerson, setContactPerson] = useState('');
  const [phone, setPhone] = useState('');
  const [message, setMessage] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.post('/Employer', { companyName,
        contactPerson,
        phone});
      setMessage('Employer created successfully!');
      setTimeout(() => {
        navigate('/');
      }, 1000);
    } catch (error) {
      console.error('Error creating Employer:', error);
      setMessage(`Failed to create Employer: ${error.response?.data || error.message}`);
    }
  };

  return (
    <div className="container mt-5">
      <h2>Create Employer</h2>
      {message && (
        <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
          {message}
        </div>
      )}
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="companyName" className="form-label">Company Name:</label>
          <input
            type="text"
            className="form-control"
            id="companyName"
            value={companyName}
            onChange={(e) => setCompanyName(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="contactPerson" className="form-label">Contact Person:</label>
          <input
            type="text"
            className="form-control"
            id="contactPerson"
            value={contactPerson}
            onChange={(e) => setContactPerson(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="phone" className="form-label">Phone:</label>
          <input
            type="text"
            className="form-control"
            id="phone"
            value={phone}
            onChange={(e) => setPhone(e.target.value)}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary">Create</button>
      </form>
    </div>
  );
}

export default EmployerCreate;