import React, {useState} from "react";
import "./LoginAttemptList.css";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

const LoginAttemptList = (props) => {

	const [filter, setFilter] = useState("");

	const { attempts = [] } = props;
	const normalizedfilter = filter.trim().toLowerCase();
	const filteredAttempts = attempts.filter(a =>
		!normalizedfilter || (a.login || "").toLowerCase().includes(normalizedfilter));
		
	return (
		<div className="Attempt-List-Main">
			<p>Recent activity</p>
			<input 
				type="input" 
				placeholder="Filter..." 
				value={filter}
				onChange={(e) => setFilter(e.target.value)}
			/>
			<ul className="Attempt-List">
				{filteredAttempts.length === 0 ? (
					<LoginAttempt>No Login attempts found</LoginAttempt>
				) : (
					filteredAttempts.map((item, index) => (
						<LoginAttempt key={index}>
							<strong>{item.login || "(username)"}</strong>
							{item.timestamp ? ` — ${new Date(item.timestamp).toLocaleString()}` : ""}
						</LoginAttempt>
					))
				)}
			</ul>
		</div>
	);
};

export default LoginAttemptList;