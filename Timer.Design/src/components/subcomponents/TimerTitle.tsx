export default function TimerTitle({
    name,
    timeLimit,
}: {
    name: string;
    timeLimit: string;
}) {
    return (
        <div className="w-full px-2 text-3xl flex gap-2 justify-between items-baseline font-bold text-start text-white text-nowrap">
            <p className="flex-grow overflow-x-clip">{name}</p>
            <p className="text-2xl font-semibold top-2 right-4">
                ({timeLimit})
            </p>
        </div>
    );
}
