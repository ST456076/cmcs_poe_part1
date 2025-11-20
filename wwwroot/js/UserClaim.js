import React, { useState, useEffect } from 'react';
import axios from 'axios';

const UserClaims = () => {
    const [claims, setClaims] = useState([]);

    useEffect(() => {
        axios.get('/api/user-claims')
            .then(response => {
                setClaims(response.data);
            })
            .catch(error => {
                console.error(error);
            });
    }, []);

    return (
        <div>
            <h1>My Claims</h1>
            <ul>
                {claims.map(claim => (
                    <li key={claim.id}>
                        {claim.details} - {claim.status}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default UserClaims;