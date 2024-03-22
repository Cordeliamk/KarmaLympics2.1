import React from 'react'
import './team.css'
import './TeamList'

interface Props{
    teamName: string;
    teamUrl: string;
    teamScore: number;
}

const Team = ({teamName, teamUrl, teamScore}: Props) => {
  return (
    <div>{teamName}
    <h2>{teamUrl}</h2>
    <p>{teamScore}</p>
    </div>
  )
}

export default Team