import { faStop, faPlay } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import TimerTitle from "./subcomponents/TimerTitle";

type timerProps = {
    name: string;
    timeLimit: string;
    bgColor: string;
    askDelete?: boolean;
};

export default function Timer({ }: timerProps) {
    return (
        <div className="bg-paused-400 timer-wrapper">
            <TimerTitle name={"Ramen"} timeLimit={"2m 36s"} />

            <div className="timer-content-wrapper">
                <button className="big-round-button hover:bg-paused-300">
                    <FontAwesomeIcon
                        className="mx-auto my-auto text-6xl translate-x-[3px]"
                        icon={faPlay}
                    />
                </button>
                <button className="big-round-button hover:bg-paused-300">
                    <FontAwesomeIcon
                        className="mx-auto my-auto text-6xl"
                        icon={faStop}
                    />
                </button>
            </div>
        </div>
    );
}
