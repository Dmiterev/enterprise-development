import React, { useState } from 'react';
import api from '../api/api';

function EmployerDelete({ id, onDeleteSuccess }) {
  const [message, setMessage] = useState('');
  const [isLoading, setIsLoading] = useState(false); 

  const handleDelete = async () => {
    const confirmDelete = window.confirm("Are you sure you want to delete this employer?");
    if (!confirmDelete) return; 

    setIsLoading(true); 
    try {
      await api.delete(`/Employer/${id}`);
      onDeleteSuccess(id);
      setMessage('Employer deleted successfully!');
    } catch (error) {
      setMessage('Failed to delete employer');
    } finally {
      setIsLoading(false); 
    }
  };

  return (
    <div>
      {message && (
        <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
          {message}
        </div>
      )}
      <button onClick={handleDelete} className="btn btn-danger btn-sm" disabled={isLoading}>
        {isLoading ? 'Deleting...' : 'Delete'}
      </button>
    </div>
  );
}

export default EmployerDelete;