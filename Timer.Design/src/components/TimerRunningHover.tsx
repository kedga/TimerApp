import { faStop, faPause } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import TimerTitle from "./subcomponents/TimerTitle";

type timerProps = {
    name: string;
    timeLimit: string;
    bgColor: string;
    askDelete?: boolean;
};

export default function Timer({ timeLimit }: timerProps) {
    return (
        <div className="bg-running-500 timer-wrapper">
            <TimerTitle name={"Ramen"} timeLimit={timeLimit} />

            <div className="timer-content-wrapper">
                <button className="big-round-button hover:bg-running-400">
                    <FontAwesomeIcon
                        className="mx-auto my-auto text-6xl"
                        icon={faPause}
                    />
                </button>
                <button className="big-round-button hover:bg-running-400">
                    <FontAwesomeIcon
                        className="mx-auto my-auto text-6xl"
                        icon={faStop}
                    />
                </button>
            </div>
        </div>
    );
}
