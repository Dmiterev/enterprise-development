import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import api from '../api/api';

const EmployerUpdate = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [companyName, setCompanyName] = useState('');
  const [contactPerson, setContactPerson] = useState('');
  const [phone, setPhone] = useState('');
  const [message, setMessage] = useState('');
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(true); 

  useEffect(() => {
    const fetchEmployer = async () => {
      try {
        const response = await api.get(`/employer/${id}`);
        setCompanyName(response.data.companyName);
        setContactPerson(response.data.contactPerson);
        setPhone(response.data.phone);
      } catch (error) {
        console.error('Error fetching employer:', error);
        setError('Employer not found');
      } finally {
        setIsLoading(false); 
      }
    };

    fetchEmployer();
  }, [id]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.put(`/employer/${id}`, { companyName, contactPerson, phone });
      setMessage('Employer updated successfully!');
      setTimeout(() => {
        navigate('/');
      }, 1000);
    } catch (error) {
      console.error('Error updating employer:', error);
      setMessage('Failed to update employer.');
    }
  };

  if (isLoading) {
    return <div>Loading...</div>; 
  }

  return (
    <div className="container mt-5">
      <h2>Edit Employer</h2>
      {message && (
        <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
          {message}
        </div>
      )}
      {error && (
        <div className="alert alert-danger" role="alert">
          {error}
        </div>
      )}
      {!error && (
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
          <button type="submit" className="btn btn-primary">Update Employer</button>
        </form>
      )}
    </div>
  );
};

export default EmployerUpdate;